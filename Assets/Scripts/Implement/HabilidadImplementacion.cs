using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Implement {
    class HabilidadImplementacion : IDaoBase<Habilidad> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private Habilidad habilidad;
        private HabilidadMapper mapper;
        private List<Habilidad> listaHabilidades;

        public HabilidadImplementacion() {
            mapper = new HabilidadMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(Habilidad habilidad) {
            sql = dataBase.insertInto( "Habilidad", new List<string>() {
                "habilidadID",
                "nombre",
                "descripcion",
                "tipo",
                "icono",
                "elementium",
                "potenciaSanacion",
                "modulador",
                "alcance",
                "estadoAlteradoID",
                "elementoID",
                "costoEnergia",
                "costoPV"
            } );

            Console.WriteLine( "Insert Habilidad : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( habilidad.HabilidadId );
            command.Parameters.Add( habilidad.Nombre );
            command.Parameters.Add( habilidad.Descripcion );
            command.Parameters.Add( habilidad.Icono );
            command.Parameters.Add( habilidad.TipoElementium );
            command.Parameters.Add( habilidad.PotenciaSanacion );
            command.Parameters.Add( habilidad.Modulador );
            command.Parameters.Add( habilidad.Alcance );
            command.Parameters.Add( habilidad.ListaEstadosAlterados );
            command.Parameters.Add( habilidad.ListaElementos );
            command.Parameters.Add( habilidad.CostoEnergia );
            command.Parameters.Add( habilidad.CostoPV );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int habilidadId) {
            sql = dataBase.deleteFrom( "Habilidad", new List<string>() { "habilidadID = @habilidadID" } );
            Console.WriteLine( "Delete Habilidad : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( habilidadId );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(Habilidad habilidad) {
            sql = dataBase.update( "Habilidad", new List<string>() {
                "habilidadID=:habilidadID",
                "nombre=:nombre",
                "descripcion=:descripcion",
                "tipo=:tipo",
                "icono=:icono",
                "elementium=:elementium",
                "potenciaSanacion=:potenciaSanacion",
                "modulador=:modulador",
                "alcance=:alcance",
                "estadoAlteradoID=:estadoAlteradoID",
                "elementoID=:elementoID",
                "costoEnergia=:costoEnergia",
                "costoPV=:costoPV"
            }, new List<string>() {
                "habilidadID=" + habilidad.HabilidadId
            } );

            Console.WriteLine( "Update Habilidad : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( habilidad.HabilidadId );
            command.Parameters.Add( habilidad.Nombre );
            command.Parameters.Add( habilidad.Descripcion );
            command.Parameters.Add( habilidad.Icono );
            command.Parameters.Add( habilidad.TipoElementium );
            command.Parameters.Add( habilidad.PotenciaSanacion );
            command.Parameters.Add( habilidad.Modulador );
            command.Parameters.Add( habilidad.Alcance );
            command.Parameters.Add( habilidad.ListaEstadosAlterados );
            command.Parameters.Add( habilidad.ListaElementos );
            command.Parameters.Add( habilidad.CostoEnergia );
            command.Parameters.Add( habilidad.CostoPV );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public Habilidad getById(int habilidadId) {
            sql = dataBase.selectAllFrom( "Habilidad", new List<string>() { "habilidadID = ?" } );
            habilidad = new Habilidad();

            command.CommandText = sql;
            command.Parameters.Add( habilidadId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    habilidad = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return habilidad;
        }

        public Habilidad getByName(string name) {
            sql = dataBase.selectAllFrom( "Habilidad", new List<string>() { "nombre = ?" } );
            habilidad = new Habilidad();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    habilidad = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return habilidad;
        }

        public List<Habilidad> getAll() {
            sql = dataBase.selectAllFrom( "Habilidad" );

            command.CommandText = sql;
            listaHabilidades = new List<Habilidad>();

            try {
                reader = command.ExecuteReader();
                listaHabilidades = mapper.getListHabilidadesFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaHabilidades;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "Habilidad" );
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
