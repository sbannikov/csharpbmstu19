using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MetricsDbProvider;
using MetricsSave.Interface;
using MetricsDbProvider.Models;

public partial class Input : System.Web.UI.Page
{
	private IDbDataProvider _db;

	protected void Page_Load(object sender, EventArgs e)
	{
		_db = new DbDataProvider();
		cbxSource.DataSource = _db.GetSources().Select((item) => new ListItem() { Text = item.Pniv, Value = item.SourceUuid });
	}

	protected void OnClick(object sender, EventArgs e)
	{
		var mark = new Mark()
		{
			ValueUuid = (new Guid()).ToString(),
			MetricsId = cbxMetrics.SelectedItem.Value,
			TimestampStart = ((long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds),
			TimestampEnd = ((long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds),
			Value = tbxMark.Text
		};

		_db.AddMark(mark);
	}

	protected void cbxSource_SelectedIndexChanged(object sender, EventArgs e)
	{
		cbxSensor.DataSource = _db.GetSensors(cbxSource.SelectedItem.Value)
			.Select((item) => new ListItem() { Text = item.State.ToString(), Value = item.SensorUuid});
	}

	protected void cbxSensor_SelectedIndexChanged(object sender, EventArgs e)
	{
		cbxMetrics.DataSource = _db.GetMetrics(cbxSensor.SelectedItem.Value).Select((item) => new ListItem() { Text = $"${item.Code} - ${item.Unit}", Value = item.ParameterUuid });
	}
}