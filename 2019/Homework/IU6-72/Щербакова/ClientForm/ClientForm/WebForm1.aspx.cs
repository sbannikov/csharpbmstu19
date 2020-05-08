using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace ClientForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Source> sources = new List<Source>();
        public List<Sensor> sensors = new List<Sensor>();
		public List<Value> values = new List<Value>();
		public List<string> Errors = new List<string>();
        public List<Utility.Parameter> parameters = new List<Utility.Parameter>();
        public Source currentSource = new Source();
        int RbIndex;        
		object ob0;


        protected void Page_Load(object sender, EventArgs e)
        {
            RbIndex = RadioButtonList0.SelectedIndex;          
            AddingObjects();
			label1.Text = "";

			foreach (var sensor in sensors)
			{
				
				if (sensor.State == "ERROR") Errors.Add(sensor.Sensor_uuid);

			}

			if (!IsPostBack)
            {
				Reset();
               
            }
			for (int i = 0; i < DropDownList1.Items.Count; i++)
			{
				if (Errors.Contains(DropDownList1.Items[i].Value)) DropDownList1.Items[i].Attributes["disabled"] = "disabled";
			}


		}

		public void Reset()
		{
			
			currentSource = sources[0];
			Image0.ImageUrl = "https://image.flaticon.com/icons/svg/2544/2544453.svg";
			Image1.ImageUrl = "https://image.flaticon.com/icons/svg/2544/2544426.svg";
			Image0.Enabled = false;
			Image1.Enabled = true;

			CreateDDL();

			RadioButtonList0.DataSource = CreateDataSource(RadioButtonList0);
			RadioButtonList0.DataTextField = "TextField";
			RadioButtonList0.DataValueField = "ValueField";
			RadioButtonList0.DataBind();
			RadioButtonList0.SelectedIndex = 0;

			
			Text1.Text = "";
				DropDownListState.Visible = false;
				Text1.Visible = true;
			

		}

		public void Img0_Click(object sender, EventArgs e)
        {
            Image0.ImageUrl = "https://image.flaticon.com/icons/svg/2544/2544453.svg";
            Image1.ImageUrl = "https://image.flaticon.com/icons/svg/2544/2544426.svg";
            Image0.Enabled = false;
            Image1.Enabled = true;
            
            currentSource = sources[0];
            Selection_Change(null,null);
        }
        public void Img1_Click(object sender, EventArgs e)
        {
            Image0.ImageUrl = "https://image.flaticon.com/icons/svg/2544/2544443.svg";
            Image1.ImageUrl = "https://image.flaticon.com/icons/svg/2544/2544435.svg";
            Image1.Enabled = false;
            Image0.Enabled = true;
            
            currentSource = sources[1];
            Selection_Change(null, null);

        }

        ICollection CreateDataSource(WebControl ddl)
        {

            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("TextField", typeof(String)));
            dt.Columns.Add(new DataColumn("ValueField", typeof(String)));

            // Populate the table with sample values.

            if (ddl.ID == "DropDownList1")
            {                
                foreach (var sensor in sensors)
                {

                    if (sensor.Parent_source_uuid == currentSource.Source_uuid)
                    {
                        dt.Rows.Add(CreateRow(sensor.Sensor_uuid.ToString() + " " + sensor.State, sensor.Sensor_uuid, dt));
                                                  
                    }
					if (sensor.State == "ERROR") Errors.Add(sensor.Sensor_uuid);

				}
            }
            else
                foreach (var parameter in parameters)
                {
                    if (parameter.Parent_sensor_uuid == DropDownList1.SelectedValue)
                        dt.Rows.Add(CreateRow(parameter.Code.ToString(), parameter.Parameter_uuid, dt));
                }


            // Create a DataView from the DataTable to act as the data source
            // for the DropDownList control.
            DataView dv = new DataView(dt);
            return dv;

        }

        DataRow CreateRow(String Text, String Value, DataTable dt)
        {

            // Create a DataRow using the DataTable defined in the 
            // CreateDataSource method.
            DataRow dr = dt.NewRow();

            // This DataRow contains the TextField and ValueField 
            // fields, as defined in the CreateDataSource method. Set the 
            // fields with the appropriate value. Remember that column 0 
            // is defined as TextField, and column 1 is defined as 
            // ValueField.
            dr[0] = Text;
            dr[1] = Value;

            return dr;

        }

       
        public void Selection_Change(object sender, EventArgs e)
        {
            RbIndex = RadioButtonList0.SelectedIndex;

			CreateDDL(); 
			
            RadioButtonList0.DataSource = CreateDataSource(RadioButtonList0);
            RadioButtonList0.DataTextField = "TextField";
            RadioButtonList0.DataValueField = "ValueField";
            RadioButtonList0.DataBind();
            RadioButtonList0.SelectedIndex = RbIndex;
            

        }
        public void Selection_Change1(object sender, EventArgs e)
        {
         
            RbIndex = RadioButtonList0.SelectedIndex;
            RadioButtonList0.DataSource = CreateDataSource(RadioButtonList0);
            RadioButtonList0.DataTextField = "TextField";
            RadioButtonList0.DataValueField = "ValueField";
            RadioButtonList0.DataBind();
            RadioButtonList0.SelectedIndex = RbIndex;           

        }
        public void Selection_Change2(object sender, EventArgs e)
        {
			
            
            RbIndex = RadioButtonList0.SelectedIndex;
            
			if (RbIndex == 9)
			{
				DropDownListState.Visible = true;
				Text1.Visible = false;				
			}
			else
			{
				DropDownListState.Visible = false;
				Text1.Visible = true;
			}
			
		}

		public void CreateDDL()
		{
			DropDownList1.DataSource = CreateDataSource(DropDownList1);
			DropDownList1.DataTextField = "TextField";
			DropDownList1.DataValueField = "ValueField";
			DropDownList1.DataBind();
			DropDownList1.SelectedIndex = 0;

			for (int i = 0; i < DropDownList1.Items.Count; i++)
			{

				if (Errors.Contains(DropDownList1.Items[i].Value)) DropDownList1.Items[i].Attributes["disabled"] = "disabled";
			}
		}

		public void SaveData(Object sender, EventArgs e)
		{
			

			if (Text1.Visible == true & String.IsNullOrWhiteSpace(Text1.Text)) label1.Text = "Необходимо что-нибудь ввести…";
			else
			{
				if (Text1.Visible == false) ob0 = DropDownListState.Text;
				else ob0 = Convert.ToInt32(Text1.Text);
				values.Add(new Value()
				{
					Value_uuid = "v" + RadioButtonList0.SelectedValue,
					Parent_parameter_uuid = RadioButtonList0.SelectedValue,
					Timestamp_start = 1559313898,
					Timestamp_end = 1559315098,
					Data = ob0

				});
				Reset();
			}


		}

		public void AddingObjects()
        {
            sources.Add(new Source()
            {
                Source_uuid = "1659c3c8-e887-4b73-bee7-b1cabf2cc8e1",
                Pniv = 1
            });

            sources.Add(new Source()
            {
                Source_uuid = "1659c3c8-e887-4b73-bee7-b1cabf2cc8e2",
                Pniv = 2
            });

            sensors.Add(new Sensor()
            {
                Sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa1",
                State = "OK",
                Parent_source_uuid = "1659c3c8-e887-4b73-bee7-b1cabf2cc8e1"
            });

            sensors.Add(new Sensor()
            {
                Sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa2",
                State = "ERROR",
                Parent_source_uuid = "1659c3c8-e887-4b73-bee7-b1cabf2cc8e1"
            });

            sensors.Add(new Sensor()
            {
                Sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa3",
                State = "OK",
                Parent_source_uuid = "1659c3c8-e887-4b73-bee7-b1cabf2cc8e2"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272851",
                Code = "H2SkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa1"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272852",
                Code = "SO2kgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa1"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272853",
                Code = "SuspendedParticulateskgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa1"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272854",
                Code = "NOxkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa1"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272855",
                Code = "COxFuelkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa1"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272856",
                Code = "COxkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa1"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272857",
                Code = "HFkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa1"
            });
            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272858",
                Code = "HClkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa1"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272859",
                Code = "NH3kgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa1"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272860",
                Code = "ElectronicSealState",
                Unit = "State",
                Type = "string",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa1"
            });

            ///

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272861",
                Code = "H2SkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa2"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272862",
                Code = "SO2kgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa2"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272863",
                Code = "SuspendedParticulateskgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa2"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272864",
                Code = "NOxkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa2"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272865",
                Code = "COxFuelkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa2"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272866",
                Code = "COxkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa2"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272867",
                Code = "HFkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa2"
            });
            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272868",
                Code = "HClkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa2"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272869",
                Code = "NH3kgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa2"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272870",
                Code = "ElectronicSealState",
                Unit = "State",
                Type = "string",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa2"
            });

            ///

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272871",
                Code = "H2SkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa3"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272872",
                Code = "SO2kgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa3"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272873",
                Code = "SuspendedParticulateskgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa3"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272874",
                Code = "NOxkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa3"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272875",
                Code = "COxFuelkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa3"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272876",
                Code = "COxkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa3"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272877",
                Code = "HFkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa3"
            });
            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272878",
                Code = "HClkgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa3"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272879",
                Code = "NH3kgPerHour",
                Unit = "kgPH",
                Type = "float",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa3"
            });

            parameters.Add(new Utility.Parameter()
            {
                Parameter_uuid = "1e95b92e-16e4-42d9-b739-ecf6d8272880",
                Code = "ElectronicSealState",
                Unit = "State",
                Type = "string",
                Parent_sensor_uuid = "bbc5c3fe-0368-466f-8d7f-eﬀfed500fa3"
            });
        }
    }
}