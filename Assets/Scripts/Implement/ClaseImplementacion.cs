using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Implement {
    class ClaseImplementacion : IDaoBase<Clase> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private Clase clase;
        private ClaseMapper mapper;
        private List<Clase> listaClases;

        public ClaseImplementacion() {
            mapper = new ClaseMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(Clase clase) {
            sql = dataBase.insertInto( "Clase", new List<string>() {
                "claseID",
                "nombre",
                "descripcion",
                "tipoElementium",
                "gradoExperiencia",
                "habilidadID",
                "itemID",
                "atributoID"
            } );

            Console.WriteLine( "Insert Clase : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( clase.ClaseId );
            command.Parameters.Add( clase.Nombre );
            command.Parameters.Add( clase.Descripcion );
            command.Parameters.Add( clase.TipoElementium );
            command.Parameters.Add( clase.GradoExperiencia );
            command.Parameters.Add( clase.ListaHabilidades );
            command.Parameters.Add( clase.ListaItems );
            command.Parameters.Add( clase.ListaAtributos );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int claseId) {
            sql = dataBase.deleteFrom( "Clase", new List<string>() { "claseID = @claseID" } );
            Console.WriteLine( "Delete Clase : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( claseId );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(Clase clase) {
            sql = dataBase.update( "Clase", new List<string>() {
                "claseID=:claseID",
                "nombre=:nombre",
                "descripcion=:descripcion",
                "tipoElementium=:tipoElementium",
                "gradoExperiencia=:gradoExperiencia",
                "habilidadID=:habilidadID",
                "itemID=:itemID",
                "atributoID=:atributoID"
            }, new List<string>() {
                "claseID=" + clase.ClaseId
            } );

            Console.WriteLine( "Update Clase : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( clase.ClaseId );
            command.Parameters.Add( clase.Nombre );
            command.Parameters.Add( clase.Descripcion );
            command.Parameters.Add( clase.TipoElementium );
            command.Parameters.Add( clase.GradoExperiencia );
            command.Parameters.Add( clase.ListaHabilidades );
            command.Parameters.Add( clase.ListaItems );
            command.Parameters.Add( clase.ListaAtributos );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public Clase getById(int claseId) {
            sql = dataBase.selectAllFrom( "Clase", new List<string>() { "claseID = ?" } );
            clase = new Clase();

            command.CommandText = sql;
            command.Parameters.Add( claseId );
            
            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    clase = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return clase;
        }

        public Clase getByName(string name) {
            sql = dataBase.selectAllFrom( "Clase", new List<string>() { "nombre = ?" } );
            clase = new Clase();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    clase = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return clase;
        }

        public List<Clase> getAll() {
            sql = dataBase.selectAllFrom( "Clase" );

            command.CommandText = sql;
            listaClases = new List<Clase>();

            try {
                reader = command.ExecuteReader();
                listaClases = mapper.getListClasesFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaClases;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "Clase" );
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
