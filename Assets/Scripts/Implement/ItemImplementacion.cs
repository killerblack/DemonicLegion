using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Implement {
    class ItemImplementacion : IDaoBase<Item> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private Item item;
        private ItemMapper mapper;
        private List<Item> listaItems;

        public ItemImplementacion() {
            mapper = new ItemMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }


        public void Add(Item item) {
            sql = dataBase.insertInto( "Item", new List<string>() {
                "itemID",
                "nombre",
                "tipo",
                "descripcion",
                "icono",
                "precio",
                "peso",
                "cantidad",
                "consumible",
                "alcance",
                "usable",
                "porcentajeExito",
                "nivel",
                "compatibleItemID",
                "atributoID",
                "armaID",
                "armaduraID",
                "elementoID"
            } );

            Console.WriteLine( "Insert Item : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( item.ItemId );
            command.Parameters.Add( item.Nombre );
            command.Parameters.Add( item.Tipo );
            command.Parameters.Add( item.Descripcion);
            command.Parameters.Add( item.Icono );
            command.Parameters.Add( item.Precio );
            command.Parameters.Add( item.Peso );
            command.Parameters.Add( item.Cantidad );
            command.Parameters.Add( item.Consumible );
            command.Parameters.Add( item.Alcance );
            command.Parameters.Add( item.Usable );
            command.Parameters.Add( item.PorcentajeExito );
            command.Parameters.Add( item.Nivel );
            command.Parameters.Add( item.ListaItemsCompatibles );
            command.Parameters.Add( item.ListaAtributos );
            command.Parameters.Add( item.ListaArmas );
            command.Parameters.Add( item.ListaArmaduras );
            command.Parameters.Add( item.ListaElementos );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int itemId) {
            sql = dataBase.deleteFrom( "Item", new List<string>() { "itemID = @itemID" } );
            Console.WriteLine( "Delete Item : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( itemId );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(Item item) {
            sql = dataBase.update( "Item", new List<string>() {
                "itemID=:itemID",
                "nombre=:nombre",
                "tipo=:tipo",
                "descripcion=:descripcion",
                "icono=:icono",
                "precio=:precio",
                "peso=:peso",
                "cantidad=:cantidad",
                "consumible=:consumible",
                "alcance=:alcance",
                "usable=:usable",
                "porcentajeExito=:porcentajeExito",
                "nivel=:nivel",
                "compatibleItemID=:compatibleItemID",
                "atributoID=:atributoID",
                "armaID=:armaID",
                "armaduraID=:armaduraID",
                "elementoID=:elementoID"
            }, new List<string>() {
                "itemID=" + item.ItemId
            } );

            Console.WriteLine( "Update Item : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( item.ItemId );
            command.Parameters.Add( item.Nombre );
            command.Parameters.Add( item.Tipo );
            command.Parameters.Add( item.Descripcion );
            command.Parameters.Add( item.Icono );
            command.Parameters.Add( item.Precio );
            command.Parameters.Add( item.Peso );
            command.Parameters.Add( item.Cantidad );
            command.Parameters.Add( item.Consumible );
            command.Parameters.Add( item.Alcance );
            command.Parameters.Add( item.Usable );
            command.Parameters.Add( item.PorcentajeExito );
            command.Parameters.Add( item.Nivel );
            command.Parameters.Add( item.ListaItemsCompatibles );
            command.Parameters.Add( item.ListaAtributos );
            command.Parameters.Add( item.ListaArmas );
            command.Parameters.Add( item.ListaArmaduras );
            command.Parameters.Add( item.ListaElementos );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public Item getById(int itemId) {
            sql = dataBase.selectAllFrom( "Item", new List<string>() { "itemID = ?" } );
            item = new Item();

            command.CommandText = sql;
            command.Parameters.Add( itemId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    item = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return item;
        }

        public Item getByName(string name) {
            sql = dataBase.selectAllFrom( "Item", new List<string>() { "nombre = ?" } );
            item = new Item();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    item = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return item;
        }

        public List<Item> getAll() {
            sql = dataBase.selectAllFrom( "Item" );

            command.CommandText = sql;
            listaItems = new List<Item>();

            try {
                reader = command.ExecuteReader();
                listaItems = mapper.getListItemsFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaItems;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "Item" );
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
