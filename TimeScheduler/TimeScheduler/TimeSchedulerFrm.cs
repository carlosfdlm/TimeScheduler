using System;
using System.Windows.Forms;
using TimeScheduler.Resources.Texts;

namespace TimeScheduler
{
    public partial class TimeSchedulerFrm : Form
    {
        Scheduler scheduler;

        public TimeSchedulerFrm()
        {
            InitializeComponent();
            this.cbType.DataSource = Enum.GetValues(typeof(ExecutionType));

        }

        private void btCalculateNextDate_Click(object sender, EventArgs e)
        {
            if (this.chkEnabled.Checked == false)
            {
                MessageBox.Show(Global.NotEnabled, Global.FormClosing, MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(this.dtpCurrentDate.Text))
            {
                MessageBox.Show(Global.CurrentDateNotCompleted, Global.FormClosing, MessageBoxButtons.OK);
                return;
            }
            try
            {
                if (this.scheduler == null)
                {
                    this.SetExecutionProperties();
                }
                this.txNextExecutionTime.Text = this.scheduler.CalculateNextExecutionDate().ToString();
                this.txExecutionDescription.Text = this.scheduler.SchedulerDescription();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, Global.FormClosing, MessageBoxButtons.OK);
            }
        }

        private void SetExecutionProperties()
        {
            this.scheduler = this.cbType.Text == ExecutionType.Recurring.ToString() ?
                      new Scheduler(new RecurringStrategy()) : new Scheduler(new OnceStrategy());
            this.scheduler.ValidateFields(Convert.ToDateTime(this.dtpDateTime.Value), Convert.ToDateTime(this.dtpStartDate.Value));
            this.scheduler.CurrentDate = Convert.ToDateTime(dtpCurrentDate.Value);
            this.scheduler.Enabled = this.chkEnabled.Checked;
            this.scheduler.DateExecution = Convert.ToDateTime(this.dtpDateTime.Value);
            this.scheduler.StartDate = Convert.ToDateTime(this.dtpStartDate.Value);
            this.scheduler.EndDate = Convert.ToDateTime(this.dtpEndDate.Value);
            this.scheduler.NumDays = Convert.ToDouble(this.nupDays.Value);
        }
    }
}
