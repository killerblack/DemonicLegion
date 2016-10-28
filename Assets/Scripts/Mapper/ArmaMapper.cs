using System;
using System.Collections.Generic;
using Entities;
using System.Data;

namespace Assets.Scripts.Mapper {
    public class ArmaMapper {

        public ArmaMapper() {}
        /*
	     * 	armaId
	     *	nombre
	     *	descripción
	     *	icono
	     *	tipo. El tipo de arma puede ser hacha, espada, etc.
	     *	precio. Cuanto cuesta el arma en tienda
         *	bonoSanacion. Cantidad de sanacion que agrega el arma a la formula de sanacion.
	     *	peso. El peso del arma afecta a la fuerza de cada ataque.
	     *	nivel. El nivel del arma con un rango de 1-20
	     *	listaAtributos. Lista de Atributos que afecta el arma como fuerza, inteligencia, etc.
	     *	listaElementos. Elemento que posee como fuego, agua, etc.
	     *	listaEstadosAlterados. Lista de estados alterados que posee el arma como maldicion, o petra, etc.
	     *	listaClases. Lista de clases que la puede equipar.
	     *	listaRazas. Lista de razas que la puede equipar.
	     *	listaItems. Lista de objetos que pueden ser equipado para mejora.
	    */
        public Arma assignValuesFrom(IDataReader reader) {
            Arma arma = new Arma();
            arma.ArmaId = (int)reader["armaID"];
            arma.Nombre = (string)reader["nombre"];
            arma.Descripcion = (string)reader["descripcion"];
            arma.Icono = (byte[])reader["icono"];
            arma.Tipo = (int)reader["tipo"];
            arma.Precio = (int)reader["precio"];
            arma.BonoSanacion = (int)reader["bonoSanacion"];
            arma.Peso = (int)reader["peso"];
            arma.Nivel = (int)reader["nivel"];
            arma.ListaAtributos = (List<Atributo>)reader["atributoId"];
            arma.ListaElementos = (List<Elemento>)reader["elementoId"];
            arma.ListaEstadosAlterados = (List<EstadoAlterado>)reader["estadoAlteradoId"];

            //arma.ListaClases = (List<Clase>) reader["claseId"];
            //arma.ListaRazas = (List<Raza>) reader["razaId"];
            //arma.ListaItems = (List<Item>) reader["itemId"];
            Console.WriteLine( "arma.ID = " + arma.ArmaId );
            return arma;
        }

        public List<Arma> getListArmasFrom(IDataReader reader) {
            List<Arma> listArmas = new List<Arma>();
            while (reader.Read()) {
                listArmas.Add( assignValuesFrom( reader ) );
            }
            return listArmas;
        }

    }
}