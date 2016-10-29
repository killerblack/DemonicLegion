using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.Dao;

namespace Assets.Scripts.Implement {
    class ElementoImplementacion : IDaoBase<Elemento> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private Elemento elemento;
        private ElementoMapper mapper;
        private List<Elemento> listaElementos;

        public ElementoImplementacion() {
            mapper = new ElementoMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(Elemento elemento) {
            sql = dataBase.insertInto( "Elemento", new List<string>() {
                "elementoID",
                "nombre",
                "icono",
                "porcentajeDamage",
                "porcentajeResistencia",
                "descripcion"
            } );

            Console.WriteLine( "Insert Elemento : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( elemento.ElementId );
            command.Parameters.Add( elemento.Nombre );
            command.Parameters.Add( elemento.Icono );
            command.Parameters.Add( elemento.PorcentajeDamage );
            command.Parameters.Add( elemento.PorcentajeResistencia );
            command.Parameters.Add( elemento.Descripcion );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int elementoId) {
            sql = dataBase.deleteFrom( "Elemento", new List<string>() { "elementoID = @elementoID" } );
            Console.WriteLine( "Delete Elemento : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( elementoId );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(Elemento elemento) {
            sql = dataBase.update( "Elemento", new List<string>() {
                "elementoID=:elementoID",
                "nombre=:nombre",
                "icono=:icono",
                "porcentajeDamage=:porcentajeDamage",
                "porcentajeResistencia=:porcentajeResistencia",
                "descripcion=:descripcion"
            }, new List<string>() {
                "elementoID=" + elemento.ElementId
            } );

            Console.WriteLine( "Update Elemento : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( elemento.ElementId );
            command.Parameters.Add( elemento.Nombre );
            command.Parameters.Add( elemento.Icono );
            command.Parameters.Add( elemento.PorcentajeDamage );
            command.Parameters.Add( elemento.PorcentajeResistencia );
            command.Parameters.Add( elemento.Descripcion );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public Elemento getById(int elementoId) {
            sql = dataBase.selectAllFrom( "Elemento", new List<string>() { "elementoID = ?" } );
            elemento = new Elemento();

            command.CommandText = sql;
            command.Parameters.Add( elementoId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    elemento = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return elemento;
        }

        public Elemento getByName(string name) {
            sql = dataBase.selectAllFrom( "Elemento", new List<string>() { "nombre = ?" } );
            elemento = new Elemento();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    elemento = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return elemento;
        }

        public List<Elemento> getAll() {
            sql = dataBase.selectAllFrom( "Elemento" );

            command.CommandText = sql;
            listaElementos = new List<Elemento>();

            try {
                reader = command.ExecuteReader();
                listaElementos = mapper.getListElementosFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaElementos;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "Elemento" );
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
