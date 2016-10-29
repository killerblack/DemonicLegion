using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.Dao;

namespace Assets.Scripts.Implement {
    class EstadoAlteradoImplementacion : IDaoBase<EstadoAlterado> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private EstadoAlterado estadoAlterado;
        private EstadoAlteradoMapper mapper;
        private List<EstadoAlterado> listaEstadosAlterados;

        public EstadoAlteradoImplementacion() {
            mapper = new EstadoAlteradoMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(EstadoAlterado estadoAlterado) {
            sql = dataBase.insertInto( "EstadoAlterado", new List<string>() {
                "estadoAlteradoID",
                "nombre",
                "descripcion",
                "icono",
                "costoEnergia",
                "atributoID"
            } );

            Console.WriteLine( "Insert EstadoAlterado : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( estadoAlterado.EstadoAlteradoId );
            command.Parameters.Add( estadoAlterado.Nombre );
            command.Parameters.Add( estadoAlterado.Descripcion );
            command.Parameters.Add( estadoAlterado.Icono );
            command.Parameters.Add( estadoAlterado.CostoEnergia );
            command.Parameters.Add( estadoAlterado.ListaAtributos );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int estadoAlteradoId) {
            sql = dataBase.deleteFrom( "EstadoAlterado", new List<string>() { "estadoAlteradoID = @estadoAlteradoID" } );
            Console.WriteLine( "Delete EstadoAlterado : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( estadoAlteradoId );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(EstadoAlterado estadoAlterado) {
            sql = dataBase.update( "EstadoAlterado", new List<string>() {
                "estadoAlteradoID=:estadoAlteradoID",
                "nombre=:nombre",
                "descripcion=:descripcion",
                "icono=:icono",
                "costoEnergia=:costoEnergia",
                "atributoID=:atributoID"
            }, new List<string>() {
                "estadoAlteradoID=" + estadoAlterado.EstadoAlteradoId
            } );

            Console.WriteLine( "Update EstadoAlterado : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( estadoAlterado.EstadoAlteradoId );
            command.Parameters.Add( estadoAlterado.Nombre );
            command.Parameters.Add( estadoAlterado.Descripcion );
            command.Parameters.Add( estadoAlterado.Icono );
            command.Parameters.Add( estadoAlterado.CostoEnergia );
            command.Parameters.Add( estadoAlterado.ListaAtributos );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public EstadoAlterado getById(int estadoAlteradoId) {
            sql = dataBase.selectAllFrom( "EstadoAlterado", new List<string>() { "estadoAlteradoID = ?" } );
            estadoAlterado = new EstadoAlterado();

            command.CommandText = sql;
            command.Parameters.Add( estadoAlteradoId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    estadoAlterado = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return estadoAlterado;
        }

        public EstadoAlterado getByName(string name) {
            sql = dataBase.selectAllFrom( "EstadoAlterado", new List<string>() { "nombre = ?" } );
            estadoAlterado = new EstadoAlterado();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    estadoAlterado = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return estadoAlterado;
        }

        public List<EstadoAlterado> getAll() {
            sql = dataBase.selectAllFrom( "EstadoAlterado" );

            command.CommandText = sql;
            listaEstadosAlterados = new List<EstadoAlterado>();

            try {
                reader = command.ExecuteReader();
                listaEstadosAlterados = mapper.getListEstadosAlteradosFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaEstadosAlterados;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "EstadoAlterado" );
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
