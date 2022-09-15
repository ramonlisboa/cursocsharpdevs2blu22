using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devs2Blu.ProjetosAula.Aula6.Jogo21
{
    public partial class Form1 : Form
    {
        public int PontuacaoP1 { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtConsole.Text += "\r\n Pressione \"Iniciar\" para começar o jogo.";
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            txtConsole.Text += "\r\n Primeira Rodada";
            txtConsole.Text += "\r\n Informe um número de 1 a 20";
            txtPlayer1.Focus();
        }

        private void btnPlayer1_Click(object sender, EventArgs e)
        {
            txtConsole.Enabled = false;
            txtConsole.Text += "\r\n Player 1 escolheu seu número...";
            PontuacaoP1 = Int32.Parse(txtPlayer1.Text);
            Thread.Sleep(2000);
            GeraNumeroPlayer2();
        }

        //Exemplo Metodo sem retornar valor
        private void GeraNumeroPlayer2()
        {
            Random rd = new Random();
            txtPlayer2.Text = rd.Next(1, 20).ToString();
            txtConsole.Text += "\r\n Player 2 escolheu seu número...";
        }

        //Exemplo Metodo retornando valor
        private int CalculaAgumaCoisa(int param1)
        {
            int resultado = param1 * 2;
            return resultado;
        }
    }
}
