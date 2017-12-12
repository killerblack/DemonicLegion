using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Implement {
    public class ArmaImplementacion : IDaoBase<Arma> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private Arma arma;
        private ArmaMapper mapper;
        private List<Arma> listaArmas;

        public ArmaImplementacion() {
            mapper = new ArmaMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(Arma armaEntity) {
            sql = dataBase.insertInto( "Arma", new List<string>() {
                "armaId",
                "nombre",
                "descripcion",
                "icono",
                "tipo",
                "precio",
                "bonoSanacion",
                "peso",
                "nivel",
                "atributoId",
                "elementoId",
                "estadoAlteradoId"
            } );

            Console.WriteLine( "Insert arma : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( armaEntity.ArmaId );
            command.Parameters.Add( armaEntity.Nombre );
            command.Parameters.Add( armaEntity.Descripcion );
            command.Parameters.Add( armaEntity.Icono );
            command.Parameters.Add( armaEntity.Tipo );
            command.Parameters.Add( armaEntity.Precio );
            command.Parameters.Add( armaEntity.BonoSanacion );
            command.Parameters.Add( armaEntity.Peso );
            command.Parameters.Add( armaEntity.Nivel );
            command.Parameters.Add( armaEntity.ListaAtributos );
            command.Parameters.Add( armaEntity.ListaElementos );
            command.Parameters.Add( armaEntity.ListaEstadosAlterados );
            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int armaId) {
            sql = dataBase.deleteFrom( "Arma", new List<string>() { "armaId = @armaId" } );
            Console.WriteLine( "Delete query : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( armaId );
            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(Arma armaEntity) {
            sql = dataBase.update( "Arma", new List<string>() {
                "armaId=:armaId",
                "nombre=:nombre",
                "descripcion=:descripcion",
                "icono=:icono",
                "tipo=:tipo",
                "precio=:precio",
                "bonoSanacion=:bonoSanacion",
                "peso=:peso",
                "nivel=:nivel",
                "atributoId=:atributoId",
                "elementoId=:elementoId",
                "estadoAlteradoId=:estadoAlteradoId"
            }, new List<string>() {
                "armaId=" + armaEntity.ArmaId
            } );

            Console.WriteLine( "Update query : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( armaEntity.ArmaId );
            command.Parameters.Add( armaEntity.Nombre );
            command.Parameters.Add( armaEntity.Descripcion );
            command.Parameters.Add( armaEntity.Icono );
            command.Parameters.Add( armaEntity.Tipo );
            command.Parameters.Add( armaEntity.Precio );
            command.Parameters.Add( armaEntity.BonoSanacion );
            command.Parameters.Add( armaEntity.Peso );
            command.Parameters.Add( armaEntity.Nivel );
            command.Parameters.Add( armaEntity.ListaAtributos );
            command.Parameters.Add( armaEntity.ListaElementos );
            command.Parameters.Add( armaEntity.ListaEstadosAlterados );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public Arma getById(int armaId) {
            sql = dataBase.selectAllFrom( "Arma", new List<string>() { "armaID = ?" } );
            arma = new Arma();

            command.CommandText = sql;
            command.Parameters.Add( armaId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    arma = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return arma;
        }

        public Arma getByName(string name) {
            sql = dataBase.selectAllFrom( "Arma", new List<string>() { "nombre = ?" } );
            arma = new Arma();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    arma = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return arma;
        }

        public List<Arma> getAll() {
            sql = dataBase.selectAllFrom( "Arma" );

            command.CommandText = sql;
            listaArmas = new List<Arma>();

            try {
                reader = command.ExecuteReader();
                listaArmas = mapper.getListArmasFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaArmas;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "Arma" );
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