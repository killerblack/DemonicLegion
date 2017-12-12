using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.Collections.Generic;

public class DBConnection : MonoBehaviour {

    private string connectionString;
    private IDbConnection connection;
    
    public IDbConnection getConnection() {
        ConnectionString = "URI=file:" + Application.dataPath + "/dataBaseUnity.sqlite";
        Console.WriteLine( "Application.dataPath : " + Application.dataPath );
        Console.WriteLine( "All Path : " + Application.dataPath + "/dataBaseUnity.sqlite" );
        //connectionString = "Data Source=/F:/Demonic Legion/Assets/DataBase/dataBaseUnity.sqlite";
        Connection = (IDbConnection) new SqliteConnection( ConnectionString );
        Connection.Open();
        return Connection;
    }

    public void exitConnection() {
        if (Connection != null) {
            Connection.Close();
        }
        Connection = null;
    }

    /**
	 * SELECT id, name FROM tableName WHERE id = ? AND name = ?;
	 * 
	 * conditionList would be handled using 
	 * id = ? AND
	 * 
	 * Removing the AND or any condition if is the last in the list
	 */
    public string selectFrom(List<string> columnList, string tableName, List<string> conditionList) {
        string query = CommandDBEnum.SELECT.ToString();
        for (int count = 0; count < columnList.Count; count++) {
            if (count != columnList.Count) {
                query += columnList[count] + CommandDBEnum.COMA;
            } else {
                query += columnList[count];
            }
        }
        query += CommandDBEnum.FROM + tableName;

        if (conditionList != null && conditionList.Count > 0) {
            query += CommandDBEnum.WHERE;
            foreach (string condition in conditionList) {
                query += condition;
            }
        }
        return query;
    }

    /**
	 * SELECT * FROM tableName;
	 */
    public string selectAllFrom(string tableName) {
        return CommandDBEnum.SELECT + "* " + CommandDBEnum.FROM + tableName;
    }

    /**
	 * SELECT * FROM tableName WHERE id = ? AND name = ?;
	 */
    public string selectAllFrom(string tableName, List<string> conditionList) {
        string query = CommandDBEnum.SELECT + "* " + CommandDBEnum.FROM + tableName;
        if (conditionList != null && conditionList.Count > 0) {
            query += CommandDBEnum.WHERE;
            foreach (string condition in conditionList) {
                query += condition;
            }
        }
        return query;
    }

    /**
	 * UPDATE Table SET Info =:info, Text =:text WHERE Id = :id;
	 * 
	 * conditionList would be handled this way to insert the strings
	 * Info =:info
	 * 
	 * Parameters are added in the command that executes the update
	 * command.Parameters.Add("info", SQLiteType.Text).Value = value;
	 * 
	*/
    public string update(string tableName, List<string> setList, List<string> conditionList) {
        string query = CommandDBEnum.UPDATE + tableName + CommandDBEnum.SET;

        for (int count = 0; count < setList.Count; count++) {
            if (count != setList.Count) {
                query += setList[count] + CommandDBEnum.COMA;
            } else {
                query += setList[count];
            }
        }
        if (conditionList != null && conditionList.Count > 0) {
            query += CommandDBEnum.WHERE;
            foreach (string condition in conditionList) {
                query += condition;
            }
        }
        return query;
    }

    /**
	 * INSERT INTO tableName (id, name, ...) VALUES (?, ?, ...)
	*/
    public string insertInto(string tableName, List<string> columnList) {
        string query = CommandDBEnum.INSERT.ToString() + CommandDBEnum.INTO + tableName + "(";

        for (int count = 0; count < columnList.Count; count++) {
            if (count != columnList.Count) {
                query += columnList[count] + CommandDBEnum.COMA;
            } else {
                query += columnList[count];
            }
        }
        query += ")" + CommandDBEnum.VALUES + "(";

        for (int count = 0; count < columnList.Count; count++) {
            if (count != columnList.Count) {
                query += "?, ";
            } else {
                query += "?)";
            }
        }
        return query;
    }

    /**
	 * "DELETE FROM tableName WHERE name = @name";
	 * command.Parameters.AddWithValue("@name", "value");
	*/
    public string deleteFrom(string tableName, List<string> conditionList) {
        string query = CommandDBEnum.DELETE.ToString() + CommandDBEnum.FROM + tableName;

        if (conditionList != null && conditionList.Count > 0) {
            query += CommandDBEnum.WHERE;
            foreach (string condition in conditionList) {
                query += condition;
            }
        }

        return query;
    }

    /**
	 * SELECT COUNT(*) FROM tableName;
	 */
    public string getCountFrom(string tableName) {
        return CommandDBEnum.SELECT.ToString() + CommandDBEnum.COUNT + "(*) " + CommandDBEnum.FROM + tableName;
    }

    /**
	 * SELECT COUNT(*) FROM tableName WHERE name=:name;
	 */
    public string getCountFrom(string tableName, List<string> conditionList) {
        string query = CommandDBEnum.SELECT.ToString() + CommandDBEnum.COUNT + "(*) " + CommandDBEnum.FROM + tableName;
        if (conditionList != null && conditionList.Count > 0) {
            query += CommandDBEnum.WHERE;
            foreach (string condition in conditionList) {
                query += condition;
            }
        }
        return query;
    }

    public IDbConnection Connection {
        get { return connection; }
        set { connection = value; }
    }
    public global::System.String ConnectionString {
        get { return connectionString; }
        set { connectionString = value; }
    }
}
