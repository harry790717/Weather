const https = require('https');

function GetWeatherData(CityNo,cb) {
	var options = {
		host: 'opendata.cwb.gov.tw',
		method: 'GET',
		path: '/api/v1/rest/datastore/F-C0032-001?&locationName=' + encodeURI(CityNo),
		headers: {
		'content-type': 'application/json',
		'Authorization': 'CWB-5E206CD9-B2A9-4FEE-876E-16A29F495FDA'
		}
	};
	var req = https.get(options, (res) => {
	res.on('data', (d) => {
		var pdata = JSON.parse(d);	
		cb(pdata.records.location[0].weatherElement,pdata.records.location[0].locationName);	
		});
	}).on('error', (e) => {
		console.error(e);
	});
}

module.exports = { 
    GetWeatherData,
};
