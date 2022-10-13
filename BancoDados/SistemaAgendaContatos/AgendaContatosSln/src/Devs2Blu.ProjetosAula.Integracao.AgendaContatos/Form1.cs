using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Data;
using Devs2Blu.ProjetosAula.Integracao.AgendaContatos.Model.Enum;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.Integracao.AgendaContatos
{
    public partial class Form1 : Form
    {
        public EstadoRepository EstadoRepository { get; set; }
        public ContatoRepository ContatoRepository { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EstadoRepository = new EstadoRepository();
            ContatoRepository = new ContatoRepository();
            PopulaComboEstados();
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            PopulaGridContatos();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaForm())
            {
                SalvaContato();
            }
        }

        #region Methods

        private void PopulaComboEstados()
        {
            MySqlDataReader rdrEstados = EstadoRepository.GetAll();

            cboEstados.DataSource = new BindingSource(rdrEstados, null);
            cboEstados.DisplayMember = "descricao";
            cboEstados.ValueMember = "uf";
        }

        private void PopulaGridContatos()
        {
            MySqlDataReader rdrContatos = ContatoRepository.GetAll();
            gridContatos.DataSource = new BindingSource(rdrContatos, null);
        }

        private bool ValidaForm()
        {
            if (txtNome.Text.Equals(""))
            {
                MessageBox.Show("Favor informar um Nome!", "Validação de Campos",MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNome.Focus();
                return false;
            }
            if (cboEstados.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("Favor informar um Estado!", "Validação de Campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboEstados.Focus();
                return false;
            }
            return true;
        }

        private void SalvaContato()
        {
            string columns, values;
            var status = rdAtivo.Checked ? StatusEnum.A : StatusEnum.I;

            columns = "nome,uf,status";
            values = $"'{txtNome.Text}','{cboEstados.SelectedValue}','{status}'";

            try
            {
                int idInsert = ContatoRepository.Insert(columns, values);
                if (idInsert > 0)
                {
                    MessageBox.Show($"Contato {idInsert} - {txtNome.Text} salvo com sucesso!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
