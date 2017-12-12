using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Implement {
    class PlantillaPocionesImplementacion : IDaoBase<PlantillaPociones> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private PlantillaPociones plantillaPociones;
        private PlantillaPocionesMapper mapper;
        private List<PlantillaPociones> listaPlantillaPocioness;

        public PlantillaPocionesImplementacion() {
            mapper = new PlantillaPocionesMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(PlantillaPociones plantillaPociones) {
            sql = dataBase.insertInto( "PlantillaPociones", new List<string>() {
                "plantillaPocionesID",
                "itemID_1",
                "itemID_2",
                "itemID_3",
                "itemID_4"
            } );

            Console.WriteLine( "Insert PlantillaPociones : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( plantillaPociones.PlantillaPocionesId );
            command.Parameters.Add( plantillaPociones.ItemId_1 );
            command.Parameters.Add( plantillaPociones.ItemId_2 );
            command.Parameters.Add( plantillaPociones.ItemId_3 );
            command.Parameters.Add( plantillaPociones.ItemId_4 );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int plantillaPocionesId) {
            sql = dataBase.deleteFrom( "PlantillaPociones", new List<string>() { "plantillaPocionesID = @plantillaPocionesID" } );
            Console.WriteLine( "Delete PlantillaPociones : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( plantillaPocionesId );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(PlantillaPociones plantillaPociones) {
            sql = dataBase.update( "PlantillaPociones", new List<string>() {
                "plantillaPocionesID=:plantillaPocionesID",
                "itemID_1=:itemID_1",
                "itemID_2=:itemID_2",
                "itemID_3=:itemID_3",
                "itemID_3=:itemID_4"
            }, new List<string>() {
                "plantillaPocionesID=" + plantillaPociones.PlantillaPocionesId
            } );

            Console.WriteLine( "Update PlantillaPociones : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( plantillaPociones.PlantillaPocionesId );
            command.Parameters.Add( plantillaPociones.ItemId_1 );
            command.Parameters.Add( plantillaPociones.ItemId_2 );
            command.Parameters.Add( plantillaPociones.ItemId_3 );
            command.Parameters.Add( plantillaPociones.ItemId_4 );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public PlantillaPociones getById(int plantillaPocionesId) {
            sql = dataBase.selectAllFrom( "PlantillaPociones", new List<string>() { "plantillaPocionesID = ?" } );
            plantillaPociones = new PlantillaPociones();

            command.CommandText = sql;
            command.Parameters.Add( plantillaPocionesId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    plantillaPociones = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return plantillaPociones;
        }

        public PlantillaPociones getByName(string name) {
            sql = dataBase.selectAllFrom( "PlantillaPociones", new List<string>() { "nombre = ?" } );
            plantillaPociones = new PlantillaPociones();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    plantillaPociones = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return plantillaPociones;
        }

        public List<PlantillaPociones> getAll() {
            sql = dataBase.selectAllFrom( "PlantillaPociones" );

            command.CommandText = sql;
            listaPlantillaPocioness = new List<PlantillaPociones>();

            try {
                reader = command.ExecuteReader();
                listaPlantillaPocioness = mapper.getListPlantillaPocionesFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaPlantillaPocioness;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "PlantillaPociones" );
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
