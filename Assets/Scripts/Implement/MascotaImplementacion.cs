using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.Dao;

namespace Assets.Scripts.Implement {
    class MascotaImplementacion : IDaoBase<Mascota> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private Mascota mascota;
        private MascotaMapper mapper;
        private List<Mascota> listaMascotas;

        public MascotaImplementacion() {
            mapper = new MascotaMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(Mascota mascota) {
            sql = dataBase.insertInto( "Mascota", new List<string>() {
                "mascotaID",
                "nombre",
                "descripcion",
                "apodo",
                "claseID",
                "atributoID"
            } );

            Console.WriteLine( "Insert Mascota : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( mascota.MascotaId );
            command.Parameters.Add( mascota.Nombre );
            command.Parameters.Add( mascota.Descripcion );
            command.Parameters.Add( mascota.Apodo );
            command.Parameters.Add( mascota.ListaClases );
            command.Parameters.Add( mascota.ListaAtributos );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int mascotaId) {
            sql = dataBase.deleteFrom( "Mascota", new List<string>() { "mascotaID = @mascotaID" } );
            Console.WriteLine( "Delete Mascota : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( mascotaId );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(Mascota mascota) {
            sql = dataBase.update( "Mascota", new List<string>() {
                "mascotaID=:mascotaID",
                "nombre=:nombre",
                "descripcion=:descripcion",
                "apodo=:apodo",
                "claseID=:claseID",
                "atributoID=:atributoID"
            }, new List<string>() {
                "mascotaID=" + mascota.MascotaId
            } );

            Console.WriteLine( "Update Mascota : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( mascota.MascotaId );
            command.Parameters.Add( mascota.Nombre );
            command.Parameters.Add( mascota.Descripcion );
            command.Parameters.Add( mascota.Apodo );
            command.Parameters.Add( mascota.ListaClases );
            command.Parameters.Add( mascota.ListaAtributos );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public Mascota getById(int mascotaId) {
            sql = dataBase.selectAllFrom( "Mascota", new List<string>() { "mascotaID = ?" } );
            mascota = new Mascota();

            command.CommandText = sql;
            command.Parameters.Add( mascotaId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    mascota = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return mascota;
        }

        public Mascota getByName(string name) {
            sql = dataBase.selectAllFrom( "Mascota", new List<string>() { "nombre = ?" } );
            mascota = new Mascota();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    mascota = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return mascota;
        }

        public List<Mascota> getAll() {
            sql = dataBase.selectAllFrom( "Mascota" );

            command.CommandText = sql;
            listaMascotas = new List<Mascota>();

            try {
                reader = command.ExecuteReader();
                listaMascotas = mapper.getListMascotasFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaMascotas;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "Mascota" );
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
