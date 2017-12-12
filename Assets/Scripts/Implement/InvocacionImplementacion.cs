using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Implement {
    class InvocacionImplementacion : IDaoBase<Invocacion> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private Invocacion invocacion;
        private InvocacionMapper mapper;
        private List<Invocacion> listaInvocaciones;

        public InvocacionImplementacion() {
            mapper = new InvocacionMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(Invocacion invocacion) {
            sql = dataBase.insertInto( "Invocacion", new List<string>() {
                "invocacionID",
                "nombre",
                "descripcion",
                "atributoID",
                "habilidadID",
                "nivel"
            } );

            Console.WriteLine( "Insert Invocacion : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( invocacion.InvocacionId );
            command.Parameters.Add( invocacion.Nombre );
            command.Parameters.Add( invocacion.Descripcion );
            command.Parameters.Add( invocacion.ListaAtributos );
            command.Parameters.Add( invocacion.ListaHabilidades );
            command.Parameters.Add( invocacion.Nivel );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int invocacionId) {
            sql = dataBase.deleteFrom( "Invocacion", new List<string>() { "invocacionID = @invocacionID" } );
            Console.WriteLine( "Delete Invocacion : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( invocacionId );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(Invocacion invocacion) {
            sql = dataBase.update( "Invocacion", new List<string>() {
                "invocacionID=:invocacionID",
                "nombre=:nombre",
                "descripcion=:descripcion",
                "atributoID=:atributoID",
                "habilidadID=:habilidadID",
                "nivel=:nivel"
            }, new List<string>() {
                "invocacionID=" + invocacion.InvocacionId
            } );

            Console.WriteLine( "Update Invocacion : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( invocacion.InvocacionId );
            command.Parameters.Add( invocacion.Nombre );
            command.Parameters.Add( invocacion.Descripcion );
            command.Parameters.Add( invocacion.ListaAtributos );
            command.Parameters.Add( invocacion.ListaHabilidades );
            command.Parameters.Add( invocacion.Nivel );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public Invocacion getById(int invocacionId) {
            sql = dataBase.selectAllFrom( "Invocacion", new List<string>() { "invocacionID = ?" } );
            invocacion = new Invocacion();

            command.CommandText = sql;
            command.Parameters.Add( invocacionId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    invocacion = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return invocacion;
        }

        public Invocacion getByName(string name) {
            sql = dataBase.selectAllFrom( "Invocacion", new List<string>() { "nombre = ?" } );
            invocacion = new Invocacion();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    invocacion = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return invocacion;
        }

        public List<Invocacion> getAll() {
            sql = dataBase.selectAllFrom( "Invocacion" );

            command.CommandText = sql;
            listaInvocaciones = new List<Invocacion>();

            try {
                reader = command.ExecuteReader();
                listaInvocaciones = mapper.getListInvocacionesFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaInvocaciones;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "Invocacion" );
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            try {
                count = Convert.ToInt32( command.ExecuteScalar() );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return count;
        }
    }
}
