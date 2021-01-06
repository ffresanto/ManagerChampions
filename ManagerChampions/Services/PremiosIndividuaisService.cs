using ManagerChampions.Models;
using ManagerChampions.Services.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ManagerChampions.Services
{
    public class PremiosIndividuaisService
    {
        private Connection _con = new Connection();
        public PremiosIndividuais Detalhe(int? idPremioIndividual)
        {
            try
            {
                var premiosIndividuais = new PremiosIndividuais();

                _con.OpenConnection();

                _con.Comando.Parameters.Clear();

                _con.Comando.CommandText = " SELECT" +
                                          " idPremioIndividual" +
                                          " ,descricao" +
                                          " FROM tb_premiosindividuais" +
                                          " WHERE idPremioIndividual = @idPremioIndividual";

                _con.Comando.Parameters.Add(Funcoes.ParametrosInsercao(idPremioIndividual, "@idPremioIndividual", DbType.Int32));

                var dt = _con.ExecutaComandoDataTable();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        premiosIndividuais.IdPremioIndividual = Convert.ToInt32(dt.Rows[0]["idPremioIndividual"].ToString());
                        premiosIndividuais.Descricao = dt.Rows[0]["descricao"].ToString();

                    }
                }

                return premiosIndividuais;

            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar realizar uma operação [" + MethodBase.GetCurrentMethod().ToString() + "]: " + ex.Message);
            }
            finally
            {
                _con.CloseConnection();
            }

        }

        public List<PremiosIndividuais> Lista()
        {
            try
            {
                _con.OpenConnection();

                var listaPremiosIndividuais = new List<PremiosIndividuais>();

                _con.Comando.Parameters.Clear();
                _con.Comando.CommandText = " SELECT" +
                                          " idPremioIndividual" +
                                          " ,descricao" +
                                          " FROM tb_premiosindividuais";

                var dt = _con.ExecutaComandoDataTable();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var premiosIndividuais = new PremiosIndividuais();

                        premiosIndividuais.IdPremioIndividual = Convert.ToInt32(dt.Rows[i]["idPremioIndividual"].ToString());
                        premiosIndividuais.Descricao = dt.Rows[i]["descricao"].ToString();

                        listaPremiosIndividuais.Add(premiosIndividuais);
                    }
                }

                return listaPremiosIndividuais;

            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar realizar uma operação [" + MethodBase.GetCurrentMethod().ToString() + "]: " + ex.Message);
            }
            finally
            {
                _con.CloseConnection();
            }

        }

        public bool Salvar(PremiosIndividuais premiosIndividuais)
        {
            try
            {
                _con.OpenConnection();

                _con.Comando.Parameters.Clear();

                if (premiosIndividuais.IdPremioIndividual == 0)
                {
                    _con.Comando.CommandText = "INSERT INTO tb_premiosindividuais (descricao) VALUES (@descricao)";
                }
                else
                {
                    _con.Comando.CommandText = "UPDATE tb_premiosindividuais SET descricao=@descricao WHERE idPremioIndividual = @idPremioIndividual";

                    _con.Comando.Parameters.Add(Funcoes.ParametrosInsercao(premiosIndividuais.IdPremioIndividual, "@idPremioIndividual", DbType.Int32));
                }

                _con.Comando.Parameters.Add(Funcoes.ParametrosInsercao(premiosIndividuais.Descricao, "@descricao", DbType.String));

                _con.Comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar realizar uma operação [" + this.GetType().Name + " - " + MethodBase.GetCurrentMethod().ToString() + "]: " + ex.Message);
            }
            finally
            {
                _con.CloseConnection();
            }
        }

        public bool Excluir(int idPremioIndividual)
        {
            try
            {
                _con.OpenConnection();

                _con.Comando.Parameters.Clear();

                _con.Comando.CommandText = "DELETE FROM tb_premiosindividuais WHERE idPremioIndividual = @idPremioIndividual";

                _con.Comando.Parameters.Add(Funcoes.ParametrosInsercao(idPremioIndividual, "@idPremioIndividual", DbType.Int32));

                _con.Comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar realizar uma operação [" + this.GetType().Name + " - " + MethodBase.GetCurrentMethod().ToString() + "]: " + ex.Message);
            }
            finally
            {
                _con.CloseConnection();
            }
        }

    }
}