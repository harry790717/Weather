const { URL } = require('url');
const request = require('request');
var apikey = 'CWB-5E206CD9-B2A9-4FEE-876E-16A29F495FDA';


function get(CityNo,cb) {
	var url = new URL('http://opendata.cwb.gov.tw/api/v1/rest/datastore/F-C0032-001?&locationName=' + CityNo);//'&format=JSON'
    request.get({
        "headers": { "content-type": "application/json","Authorization": 'CWB-5E206CD9-B2A9-4FEE-876E-16A29F495FDA'},
        "url": url   
    }, (error, response, body) => {
        if (error) {
            console.dir(error);
            cb(false,null);
        }
        var pdata = JSON.parse(body);
        cb(pdata.records.location[0].weatherElement,pdata.records.location[0].locationName);
        
    });
}


 
// [START exports]
module.exports = { 
    get,
}; 