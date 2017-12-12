using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Implement {
    class PlantillaArmaImplementacion : IDaoBase<PlantillaArma> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private PlantillaArma plantillaArma;
        private PlantillaArmaMapper mapper;
        private List<PlantillaArma> listaPlantillaArmas;

        public PlantillaArmaImplementacion() {
            mapper = new PlantillaArmaMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(PlantillaArma plantillaArma) {
            sql = dataBase.insertInto( "PlantillaArma", new List<string>() {
                "plantillaArmaID",
                "armaID",
                "itemID_1",
                "itemID_2",
                "itemID_3"
            } );

            Console.WriteLine( "Insert PlantillaArma : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( plantillaArma.PlantillaArmaId );
            command.Parameters.Add( plantillaArma.ArmaId );
            command.Parameters.Add( plantillaArma.ItemId_1 );
            command.Parameters.Add( plantillaArma.ItemId_2 );
            command.Parameters.Add( plantillaArma.ItemId_3 );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int plantillaArmaId) {
            sql = dataBase.deleteFrom( "PlantillaArma", new List<string>() { "plantillaArmaID = @plantillaArmaID" } );
            Console.WriteLine( "Delete PlantillaArma : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( plantillaArmaId );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(PlantillaArma plantillaArma) {
            sql = dataBase.update( "PlantillaArma", new List<string>() {
                "plantillaArmaID=:plantillaArmaID",
                "armaID=:armaID",
                "itemID_1=:itemID_1",
                "itemID_2=:itemID_2",
                "itemID_3=:itemID_3"
            }, new List<string>() {
                "plantillaArmaID=" + plantillaArma.PlantillaArmaId
            } );

            Console.WriteLine( "Update PlantillaArma : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( plantillaArma.PlantillaArmaId );
            command.Parameters.Add( plantillaArma.ArmaId );
            command.Parameters.Add( plantillaArma.ItemId_1 );
            command.Parameters.Add( plantillaArma.ItemId_2 );
            command.Parameters.Add( plantillaArma.ItemId_3 );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public PlantillaArma getById(int plantillaArmaId) {
            sql = dataBase.selectAllFrom( "PlantillaArma", new List<string>() { "plantillaArmaID = ?" } );
            plantillaArma = new PlantillaArma();

            command.CommandText = sql;
            command.Parameters.Add( plantillaArmaId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    plantillaArma = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return plantillaArma;
        }

        public PlantillaArma getByName(string name) {
            sql = dataBase.selectAllFrom( "PlantillaArma", new List<string>() { "nombre = ?" } );
            plantillaArma = new PlantillaArma();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    plantillaArma = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return plantillaArma;
        }

        public List<PlantillaArma> getAll() {
            sql = dataBase.selectAllFrom( "PlantillaArma" );

            command.CommandText = sql;
            listaPlantillaArmas = new List<PlantillaArma>();

            try {
                reader = command.ExecuteReader();
                listaPlantillaArmas = mapper.getListPlantillaArmasFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaPlantillaArmas;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "PlantillaArma" );
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
