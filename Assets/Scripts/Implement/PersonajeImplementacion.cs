using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Implement {
    class PersonajeImplementacion : IDaoBase<Personaje> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private Personaje personaje;
        private PersonajeMapper mapper;
        private List<Personaje> listaPersonajes;

        public PersonajeImplementacion() {
            mapper = new PersonajeMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(Personaje personaje) {
            sql = dataBase.insertInto( "Personaje", new List<string>() {
                "personajeID",
                "nombre",
                "peso",
                "atributoID",
                "claseID",
                "razaID",
                "itemID"
            } );

            Console.WriteLine( "Insert Personaje : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( personaje.PersonajeId );
            command.Parameters.Add( personaje.Nombre );
            command.Parameters.Add( personaje.Peso );
            command.Parameters.Add( personaje.ListaAtributos );
            command.Parameters.Add( personaje.ListaClases );
            command.Parameters.Add( personaje.Raza );
            command.Parameters.Add( personaje.ListaItems );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int personajeId) {
            sql = dataBase.deleteFrom( "Personaje", new List<string>() { "personajeID = @personajeID" } );
            Console.WriteLine( "Delete Personaje : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( personajeId );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(Personaje personaje) {
            sql = dataBase.update( "Personaje", new List<string>() {
                "personajeID=:personajeID",
                "nombre=:nombre",
                "peso=:peso",
                "atributoID=:atributoID",
                "claseID=:claseID",
                "razaID=:razaID",
                "itemID=:itemID"
            }, new List<string>() {
                "personajeID=" + personaje.PersonajeId
            } );

            Console.WriteLine( "Update Personaje : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( personaje.PersonajeId );
            command.Parameters.Add( personaje.Nombre );
            command.Parameters.Add( personaje.Peso );
            command.Parameters.Add( personaje.ListaAtributos );
            command.Parameters.Add( personaje.ListaClases );
            command.Parameters.Add( personaje.Raza );
            command.Parameters.Add( personaje.ListaItems );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public Personaje getById(int personajeId) {
            sql = dataBase.selectAllFrom( "Personaje", new List<string>() { "personajeID = ?" } );
            personaje = new Personaje();

            command.CommandText = sql;
            command.Parameters.Add( personajeId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    personaje = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return personaje;
        }

        public Personaje getByName(string name) {
            sql = dataBase.selectAllFrom( "Personaje", new List<string>() { "nombre = ?" } );
            personaje = new Personaje();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    personaje = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return personaje;
        }

        public List<Personaje> getAll() {
            sql = dataBase.selectAllFrom( "Personaje" );

            command.CommandText = sql;
            listaPersonajes = new List<Personaje>();

            try {
                reader = command.ExecuteReader();
                listaPersonajes = mapper.getListPersonajesFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaPersonajes;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "Personaje" );
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
