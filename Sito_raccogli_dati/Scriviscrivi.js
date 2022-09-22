const fs = require("fs");

const anchorkWh = document.getElementById("kWh");
const anchorSmc = document.getElementById("Smc");
Nascondi();
WriteJson();
function Nascondi(){
    
}

function GetData(){

}

function WriteJson(){
    const object = 
    {
        "kWh" : 2700,
        "Smc" : 1300,
        "selezione" : 1
    }
    const data = JSON.stringify(object);
    fs.writeFile("output.json" , data, function(err){
        if (err) throw err;
        console.log("ye");
    });
}
function Buttons(){
    document.getElementById("").addEventListener("click", Nascondi());
    document.getElementById("").addEventListener("click", GetData());
}