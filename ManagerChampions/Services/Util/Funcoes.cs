using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ManagerChampions.Services.Util
{
    public class Funcoes
    {
        public static MySqlParameter ParametrosInsercao(object valor, string nome, DbType tipoDb = default)
        {
            try
            {
                var myParam = new MySqlParameter();

                myParam.Value = valor;
                myParam.ParameterName = nome;
                myParam.DbType = tipoDb;

                return myParam;
            }
            catch (Exception)
            {
                return default;
            }
        }

    }
}