const api = require('./Weather.js');
WeatherArr = new Array(5);
CityNoArr = ['新北市','臺北市','桃園市'];

Start();

function Start(){
setInterval(Begin,360000);
}
 
async function Begin() {
	for(c=0 ; c < 3 ; c++ ){
		await WeatherGo(c);
	} 
}  

async function  WeatherGo(c){
		const getData = await Main(CityNoArr[c],c);
		const getData1 = await WriteDB(getData,c);
} 


async function Main(CityNo) {
	const getData = new Promise((resolve, reject) => {
	api.get(CityNo, function b(CityDataArr,City){
		WeatherArr[0]=City;
		for ( i=1 ; i < 6 ; i++ ){				
			WeatherArr[i] = CityDataArr[i-1].time[0].parameter.parameterName;
			}
			try {
				resolve({WeatherArr});
			}catch(error){
				reject(error)
			}  
		})
	})
	return getData;
}      

async function WriteDB(DataStr,c){

	const getData1 = new Promise((resolve, reject) => {
	var express=require('express');
	var app=express();  
	var sql=require('mssql');
	//config for your database
	 var config={ 
		user:'HarryAdmin', 
		password:'',
		server:'harrydbservice.database.windows.net', 
		database:'HarryDB',
		encrypt:true 
	 };
	 sql.connect(config,function (err) {
	   var request=new sql.Request();
	   request.query("insert into Weather(CityNo,AddDatetime,Wx,PoP,MinT,CI,MaxT) values ('" + DataStr.WeatherArr[0] + "',getDate(),'" + DataStr.WeatherArr[1] + "','" + DataStr.WeatherArr[2] + "','" + DataStr.WeatherArr[3] + "','" + DataStr.WeatherArr[4] + "','" + DataStr.WeatherArr[5] + "')",function(err,recordset){
	   try {
			resolve(DataStr.WeatherArr[0]+'新增成功');
			}catch(error){
				reject(error)
			} 
	    
	   })  
	 })
	})
	return (getData1); 
}



