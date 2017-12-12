using System;
using Entities;
using System.Collections.Generic;
using System.Data;
using Assets.Scripts.Mapper;
using Assets.Scripts.DataBase;

namespace Assets.Scripts.Implement {
    public class ArmaduraImplementacion : IDaoBase<Armadura> {
        private DBConnection dataBase;
        private IDbCommand command;
        private IDataReader reader;
        private string sql;
        private Armadura armadura;
        private ArmaduraMapper mapper;
        private List<Armadura> listaArmaduras;

        public ArmaduraImplementacion() {
            mapper = new ArmaduraMapper();
            dataBase = new DBConnection();
            command = dataBase.getConnection().CreateCommand();
        }

        public void Add(Armadura armadura) {
            if (armadura == null) {
                throw new System.ArgumentNullException( "Argument is invalid " );
            }

            sql = dataBase.insertInto( "Armadura", new List<string>() {
                "armaduraId",
                "nombre",
                "descripcion",
                "icono",
                "tipo",
                "precio",
                "peso",
                "nivel",
                "elementoId",
                "estadoAlteradoId",
                "atributoId"
            } );

            Console.WriteLine( "Insert armadura : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( armadura.ArmaduraId );
            command.Parameters.Add( armadura.Nombre );
            command.Parameters.Add( armadura.Descripcion );
            command.Parameters.Add( armadura.Icono );
            command.Parameters.Add( armadura.Tipo );
            command.Parameters.Add( armadura.Precio );
            command.Parameters.Add( armadura.Peso );
            command.Parameters.Add( armadura.Nivel );
            command.Parameters.Add( armadura.ListaElementos );
            command.Parameters.Add( armadura.ListaEstadosAlterados );
            command.Parameters.Add( armadura.ListaAtributos );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Delete(int armaduraId) {
            sql = dataBase.deleteFrom( "Armadura", new List<string>() { "armaduraId = @armaduraId" } );
            Console.WriteLine( "Delete armadura : " + sql );
            command.CommandText = sql;
            command.Parameters.Add( armaduraId );
            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public void Update(Armadura armadura) {
            sql = dataBase.update( "Armadura", new List<string>() {
                "armaduraId=:armaduraId",
                "nombre=:nombre",
                "descripcion=:descripcion",
                "icono=:icono",
                "tipo=:tipo",
                "precio=:precio",
                "peso=:peso",
                "nivel=:nivel",
                "elementoId=:elementoId",
                "estadoAlteradoId=:estadoAlteradoId",
                "atributoId=:atributoId"
            }, new List<string>() {
                "armaduraId=" + armadura.ArmaduraId
            } );

            Console.WriteLine( "Update query : " + sql );

            command.CommandText = sql;
            command.Parameters.Add( armadura.ArmaduraId);
            command.Parameters.Add( armadura.Nombre );
            command.Parameters.Add( armadura.Descripcion );
            command.Parameters.Add( armadura.Icono );
            command.Parameters.Add( armadura.Tipo );
            command.Parameters.Add( armadura.Precio );
            command.Parameters.Add( armadura.Peso);
            command.Parameters.Add( armadura.Nivel);
            command.Parameters.Add( armadura.ListaElementos);
            command.Parameters.Add( armadura.ListaEstadosAlterados );
            command.Parameters.Add( armadura.ListaAtributos );

            try {
                command.ExecuteNonQuery();
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
        }

        public Armadura getById(int armaduraId) {
            sql = dataBase.selectAllFrom( "Armadura", new List<string>() { "armaduraID = ?" } );
            armadura = new Armadura();

            command.CommandText = sql;
            command.Parameters.Add( armaduraId );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    armadura = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return armadura;
        }

        public Armadura getByName(string name) {
            sql = dataBase.selectAllFrom( "Armadura", new List<string>() { "nombre = ?" } );
            armadura = new Armadura();

            command.CommandText = sql;
            command.Parameters.Add( name );

            try {
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    armadura = mapper.assignValuesFrom( reader );
                }
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return armadura;
        }

        public List<Armadura> getAll() {
            sql = dataBase.selectAllFrom( "Armadura" );

            command.CommandText = sql;
            listaArmaduras = new List<Armadura>();

            try {
                reader = command.ExecuteReader();
                listaArmaduras = mapper.getListArmadurasFrom( reader );
            } catch (Exception e) {
                Console.WriteLine( e.GetBaseException() );
                throw new Exception( e.Message );
            } finally {
                dataBase.exitConnection();
            }
            return listaArmaduras;
        }

        public int getCount() {
            int count = 0;
            sql = dataBase.getCountFrom( "Armadura" );
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
