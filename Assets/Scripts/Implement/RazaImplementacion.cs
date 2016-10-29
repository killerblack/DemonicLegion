using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.Dao;

namespace Assets.Scripts.Implement {
    class RazaImplementacion : IDaoBase<Raza> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private Raza raza;
        private RazaMapper mapper;
        private List<Raza> listaRazas;

        public RazaImplementacion() {
            mapper = new RazaMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(Raza raza) {
            sql = dataBase.insertInto( "Raza", new List<string>() {
                "razaID",
                "nombre",
                "descripcion",
                "atributoID",
                "invocacionID"
            } );

            Console.WriteLine( "Insert Raza : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( raza.RazaId );
            command.Parameters.Add( raza.Nombre );
            command.Parameters.Add( raza.Descripcion );
            command.Parameters.Add( raza.ListaAtributos );
            command.Parameters.Add( raza.ListaInvocacionesRaciales );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int razaId) {
            sql = dataBase.deleteFrom( "Raza", new List<string>() { "razaID = @razaID" } );
            Console.WriteLine( "Delete Raza : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( razaId );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(Raza raza) {
            sql = dataBase.update( "Raza", new List<string>() {
                "razaID=:razaID",
                "nombre=:nombre",
                "descripcion=:descripcion",
                "atributoID=:atributoID",
                "invocacionID=:invocacionID"
            }, new List<string>() {
                "razaID=" + raza.RazaId
            } );

            Console.WriteLine( "Update Raza : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( raza.RazaId );
            command.Parameters.Add( raza.Nombre );
            command.Parameters.Add( raza.Descripcion );
            command.Parameters.Add( raza.ListaAtributos );
            command.Parameters.Add( raza.ListaInvocacionesRaciales );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public Raza getById(int razaId) {
            sql = dataBase.selectAllFrom( "Raza", new List<string>() { "razaID = ?" } );
            raza = new Raza();

            command.CommandText = sql;
            command.Parameters.Add( razaId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    raza = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return raza;
        }

        public Raza getByName(string name) {
            sql = dataBase.selectAllFrom( "Raza", new List<string>() { "nombre = ?" } );
            raza = new Raza();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    raza = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return raza;
        }

        public List<Raza> getAll() {
            sql = dataBase.selectAllFrom( "Raza" );

            command.CommandText = sql;
            listaRazas = new List<Raza>();

            try {
                reader = command.ExecuteReader();
                listaRazas = mapper.getListRazasFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaRazas;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "Raza" );
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
