using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    class ItemMapper {

        public ItemMapper() { }
        /*
         * itemId
         * nombre
         * tipo
         * descripción
         * icono
         * precio
         * peso
         * cantidad. Numero de objetos disponibles
         * consumible. que se termina si se usa depende la cantidad que haya del objeto
         * alcance. Un jugador, varios enemigos, etc.
         * usableEn. donde es usable
         * pocentajeExito. porcentaje de éxito al ser usado
         * nivel. Comparable con el nivel del personaje
         * listaItemsCompatibles. Compatibles para combinaciones
         * listaAtributos. Atributos que afecta al ser usado o equipado
         * listaArmas. Arma(s) aplicable(s)
         * listaArmaduras. Armadura(s) aplicables(s)
         * listaElementos. posibles elementos ligados al objeto
         * 
        */
        public Item assignValuesFrom(IDataReader reader) {
            Item item = new Item();
            item.ItemId = (int) reader["itemID"];
            item.Nombre = (string) reader["nombre"];
            item.Tipo = (string) reader["tipo"];
            item.Descripcion = (string) reader["descripcion"];
            item.Icono = (byte[]) reader["icono"];
            item.Precio = (int) reader["precio"];
            item.Peso = (int) reader["peso"];
            item.Cantidad = (int) reader["cantidad"];
            item.Consumible = (int) reader["consumible"];
            item.Alcance = (string) reader["alcance"];
            item.Usable = (string) reader["usable"];
            item.PorcentajeExito = (int) reader["porcentajeExito"];
            item.Nivel = (int) reader["nivel"];
            item.ListaItemsCompatibles = (List<Item>) reader["compatibleItemID"];
            item.ListaAtributos = (List<Atributo>) reader["atributoID"];
            item.ListaArmas = (List<Arma>) reader["armaID"];
            item.ListaArmaduras = (List<Armadura>) reader["armaduraID"];
            item.ListaElementos = (List<Elemento>) reader["elementoID"];

            return item;
        }

        public List<Item> getListItemsFrom(IDataReader reader) {
            List<Item> listItems = new List<Item>();
            while (reader.Read()) {
                listItems.Add( assignValuesFrom( reader ) );
            }
            return listItems;
        }
    }
}
