using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.Dao;

namespace Assets.Scripts.Implement {
    class AtributoImplementacion : IDaoBase<Atributo> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private Atributo atributo;
        private AtributoMapper mapper;
        private List<Atributo> listaAtributos;

        public AtributoImplementacion() {
            mapper = new AtributoMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(Atributo atributo) {
            sql = dataBase.insertInto( "Atributo", new List<string>() {
                "atributoId",
                "nombre",
                "descripcion",
                "valor"
            } );

            Console.WriteLine( "Insert Atributo : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( atributo.AtributoId );
            command.Parameters.Add( atributo.Nombre );
            command.Parameters.Add( atributo.Descripcion );
            command.Parameters.Add( atributo.Valor );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int atributoId) {
            sql = dataBase.deleteFrom( "Atributo", new List<string>() { "atributoId = @atributoId" } );
            Console.WriteLine( "Delete Atributo : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( atributoId );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(Atributo atributo) {
            sql = dataBase.update( "Atributo", new List<string>() {
                "atributoId=:atributoId",
                "nombre=:nombre",
                "descripcion=:descripcion",
                "valor=:valor"
            }, new List<string>() {
                "atributoId=" + atributo.AtributoId
            } );

            Console.WriteLine( "Update query : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( atributo.AtributoId);
            command.Parameters.Add( atributo.Nombre );
            command.Parameters.Add( atributo.Descripcion );
            command.Parameters.Add( atributo.Valor);

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public Atributo getById(int atributoId) {
            sql = dataBase.selectAllFrom( "Atributo", new List<string>() { "atributoID = ?" } );
            atributo = new Atributo();

            command.CommandText = sql;
            command.Parameters.Add( atributoId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    atributo = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return atributo;
        }

        public Atributo getByName(string name) {
            sql = dataBase.selectAllFrom( "Atributo", new List<string>() { "nombre = ?" } );
            atributo = new Atributo();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    atributo = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return atributo;
        }

        public List<Atributo> getAll() {
            sql = dataBase.selectAllFrom( "Atributo" );

            command.CommandText = sql;
            listaAtributos = new List<Atributo>();

            try {
                reader = command.ExecuteReader();
                listaAtributos = mapper.getListAtributosFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaAtributos;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "Atributo" );
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
