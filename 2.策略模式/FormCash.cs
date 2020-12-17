using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 策略模式
{
    public partial class CashWin : Form
    {
        double total = 0;

        public CashWin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 策略模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            CashContext cc = null;
            switch (cbxType.SelectedItem.ToString())
            {
                case "正常收费":
                    cc = new CashContext(new CashNormal());
                    break;
                case "满300减100":
                    cc = new CashContext(new CashReturn("300", "100"));
                    break;
                case "打8折":
                    cc = new CashContext(new CashRebate("0.8"));
                    break;
                default:
                    break;
            }
            // CashSuper csuper = CashFactory.createCashAccept(cbxType.SelectedItem.ToString());
            double totalPrices = 0;
            totalPrices = cc.GetResult(Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text));
            total = total + totalPrices;
            lblList.Items.Add("模式:" + cbxType.SelectedItem.ToString() + "单价:" + txtPrice.Text + "  数量:" + txtNum.Text + "  合计:" + totalPrices.ToString());
            lblResult.Text = total.ToString();
        }

        /// <summary>
        /// 策略模式和工场模式结合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click1(object sender, EventArgs e)
        {
            // CashSuper csuper = CashFactory.createCashAccept(cbxType.SelectedItem.ToString());
            CashContext csuper = new CashContext(cbxType.SelectedItem.ToString());
            double totalPrices = 0;
            totalPrices = csuper.GetResult(Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text));
            total = total + totalPrices;
            lblList.Items.Add("模式:" + cbxType.SelectedItem.ToString() + "单价:" + txtPrice.Text + "  数量:" + txtNum.Text + "  合计:" + totalPrices.ToString());
            lblResult.Text = total.ToString();
        }
    }
}
