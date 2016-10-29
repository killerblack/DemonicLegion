using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.Dao;

namespace Assets.Scripts.Implement {
    class PlantillaArmaduraImplementacion : IDaoBase<PlantillaArmadura> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private PlantillaArmadura plantillaArmadura;
        private PlantillaArmaduraMapper mapper;
        private List<PlantillaArmadura> listaPlantillaArmaduras;

        public PlantillaArmaduraImplementacion() {
            mapper = new PlantillaArmaduraMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(PlantillaArmadura plantillaArmadura) {
            sql = dataBase.insertInto( "PlantillaArmadura", new List<string>() {
                "plantillaArmaduraID",
                "armaduraID",
                "itemID_1",
                "itemID_2",
                "itemID_3"
            } );

            Console.WriteLine( "Insert PlantillaArmadura : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( plantillaArmadura.PlantillaArmaduraId );
            command.Parameters.Add( plantillaArmadura.ArmaduraId );
            command.Parameters.Add( plantillaArmadura.ItemId_1 );
            command.Parameters.Add( plantillaArmadura.ItemId_2 );
            command.Parameters.Add( plantillaArmadura.ItemId_3 );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int plantillaArmaduraId) {
            sql = dataBase.deleteFrom( "PlantillaArmadura", new List<string>() { "plantillaArmaduraID = @plantillaArmaduraID" } );
            Console.WriteLine( "Delete PlantillaArmadura : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( plantillaArmaduraId );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(PlantillaArmadura plantillaArmadura) {
            sql = dataBase.update( "PlantillaArmadura", new List<string>() {
                "plantillaArmaduraID=:plantillaArmaduraID",
                "armaduraID=:armaduraID",
                "itemID_1=:itemID_1",
                "itemID_2=:itemID_2",
                "itemID_3=:itemID_3"
            }, new List<string>() {
                "plantillaArmaduraID=" + plantillaArmadura.PlantillaArmaduraId
            } );

            Console.WriteLine( "Update PlantillaArmadura : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( plantillaArmadura.PlantillaArmaduraId );
            command.Parameters.Add( plantillaArmadura.ArmaduraId );
            command.Parameters.Add( plantillaArmadura.ItemId_1 );
            command.Parameters.Add( plantillaArmadura.ItemId_2 );
            command.Parameters.Add( plantillaArmadura.ItemId_3 );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public PlantillaArmadura getById(int plantillaArmaduraId) {
            sql = dataBase.selectAllFrom( "PlantillaArmadura", new List<string>() { "plantillaArmaduraID = ?" } );
            plantillaArmadura = new PlantillaArmadura();

            command.CommandText = sql;
            command.Parameters.Add( plantillaArmaduraId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    plantillaArmadura = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return plantillaArmadura;
        }

        public PlantillaArmadura getByName(string name) {
            sql = dataBase.selectAllFrom( "PlantillaArmadura", new List<string>() { "nombre = ?" } );
            plantillaArmadura = new PlantillaArmadura();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    plantillaArmadura = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return plantillaArmadura;
        }

        public List<PlantillaArmadura> getAll() {
            sql = dataBase.selectAllFrom( "PlantillaArmadura" );

            command.CommandText = sql;
            listaPlantillaArmaduras = new List<PlantillaArmadura>();

            try {
                reader = command.ExecuteReader();
                listaPlantillaArmaduras = mapper.getListPlantillaArmadurasFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaPlantillaArmaduras;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "PlantillaArmadura" );
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
