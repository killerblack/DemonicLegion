using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    class ArmaduraMapper {

        public ArmaduraMapper() {}
        /**
         * 	id
         *	nombre
         *	descripción
         *	icono
         *	tipo
         *	precio
         *	peso. El peso del arma afecta a la fuerza de cada ataque.
         *	nivel. El nivel del arma con un rango de 1-20
         *	listaElementos. lista de elementos que tiene la armadura
         *	listaEstadosAlterados. Lista de estados alterados que posee el arma como maldicion, o petra, etc.
         *	listaAtributos. Lista de atributos que afecta como fuerza, inteligencia, etc.
         *	
         *	listaClases. Lista de clases que la puede equipar.
         *	listaRazas. Lista de razas que la puede equipar.
         *	listaItems. Lista de objetos que pueden ser equipado para mejora.
         
         *
         **/
        public Armadura assignValuesFrom(IDataReader reader) {
            Armadura armadura = new Armadura();
            armadura.ArmaduraId = (int) reader["armaduraID"];
            armadura.Nombre = (string) reader["nombre"];
            armadura.Descripcion = (string) reader["descripcion"];
            armadura.Icono = (byte[]) reader["icono"];
            armadura.Tipo = (int) reader["tipo"];
            armadura.Precio = (int) reader["precio"];
            armadura.Peso = (int) reader["peso"];
            armadura.Nivel = (int) reader["nivel"];
            armadura.ListaElementos = (List<Elemento>) reader["elementoId"];
            armadura.ListaEstadosAlterados = (List<EstadoAlterado>) reader["estadoAlteradoId"];
            armadura.ListaAtributos = (List<Atributo>) reader["atributoId"];

            //armadura.ListaClases = (List<Clase>) reader["claseId"];
            //armadura.ListaRazas = (List<Raza>) reader["razaId"];
            //armadura.ListaItems = (List<Item>) reader["itemId"];

            Console.WriteLine( "armadura.armaduraID = " + armadura.ArmaduraId );
            return armadura;
        }

        public List<Armadura> getListArmadurasFrom(IDataReader reader) {
            List<Armadura> listArmaduras = new List<Armadura>();
            while (reader.Read()) {
                listArmaduras.Add( assignValuesFrom( reader ) );
            }
            return listArmaduras;
        }

    }
}
