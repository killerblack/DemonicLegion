using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Implement {
    class EnemigoImplementacion : IDaoBase<Enemigo> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private Enemigo enemigo;
        private EnemigoMapper mapper;
        private List<Enemigo> listaEnemigos;

        public EnemigoImplementacion() {
            mapper = new EnemigoMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(Enemigo enemigo) {
            sql = dataBase.insertInto( "Enemigo", new List<string>() {
                "enemigoID",
                "nombre",
                "nivel",
                "experiencia",
                "atributoID",
                "razaID",
                "claseID", 
                "itemID",
                "gold"
            } );

            Console.WriteLine( "Insert Enemigo : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( enemigo.EnemigoId );
            command.Parameters.Add( enemigo.Nombre );
            command.Parameters.Add( enemigo.Nivel );
            command.Parameters.Add( enemigo.Experiencia );
            command.Parameters.Add( enemigo.ListaAtributos );
            command.Parameters.Add( enemigo.Raza );
            command.Parameters.Add( enemigo.ListaClases );
            command.Parameters.Add( enemigo.ListaObjetos );
            command.Parameters.Add( enemigo.Gold );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int enemigoId) {
            sql = dataBase.deleteFrom( "Enemigo", new List<string>() { "enemigoId = @enemigoId" } );
            Console.WriteLine( "Delete Enemigo : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( enemigoId );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(Enemigo enemigo) {
            sql = dataBase.update( "Enemigo", new List<string>() {
                "enemigoID=:enemigoID",
                "nombre=:nombre",
                "nivel=:nivel",
                "experiencia=:experiencia",
                "atributoID=:atributoID",
                "razaID=:razaID",
                "claseID=:claseID",
                "itemID=:itemID",
                "gold=:gold"
            }, new List<string>() {
                "enemigoID=" + enemigo.EnemigoId
            } );

            Console.WriteLine( "Update Enemigo : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( enemigo.EnemigoId );
            command.Parameters.Add( enemigo.Nombre );
            command.Parameters.Add( enemigo.Nivel );
            command.Parameters.Add( enemigo.Experiencia );
            command.Parameters.Add( enemigo.ListaAtributos );
            command.Parameters.Add( enemigo.Raza );
            command.Parameters.Add( enemigo.ListaClases );
            command.Parameters.Add( enemigo.ListaObjetos );
            command.Parameters.Add( enemigo.Gold );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public Enemigo getById(int enemigoId) {
            sql = dataBase.selectAllFrom( "Enemigo", new List<string>() { "enemigoID = ?" } );
            enemigo = new Enemigo();

            command.CommandText = sql;
            command.Parameters.Add( enemigoId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    enemigo = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return enemigo;
        }

        public Enemigo getByName(string name) {
            sql = dataBase.selectAllFrom( "Enemigo", new List<string>() { "nombre = ?" } );
            enemigo = new Enemigo();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    enemigo = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return enemigo;
        }

        public List<Enemigo> getAll() {
            sql = dataBase.selectAllFrom( "Enemigo" );

            command.CommandText = sql;
            listaEnemigos = new List<Enemigo>();

            try {
                reader = command.ExecuteReader();
                listaEnemigos = mapper.getListEnemigosFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaEnemigos;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "Enemigo" );
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
