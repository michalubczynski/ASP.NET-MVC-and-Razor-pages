'use strict';
function Walec() {
    let h = document.getElementById('h').value;
    if (h % 2 === 1) {
        document.getElementById('stopka').innerHTML = "Wysokosc musi byc podzielna przez 2 bez reszty";
    }
    else{
        let r = document.getElementById('r').value;
        let pPodstawy = Math.PI * r * r;
        let objetosc = pPodstawy * h;
        let pPowierzchniBocznej = 2 * Math.PI * r * h;
        let pPowierzchniCalkowitej = 2 * pPodstawy + pPowierzchniBocznej;
        //document.getElementById('stopka').innerHTML = '</br>Pole podstawy:' + pPodstawy.toFixed(2) + '</br>Objetosc:' + objetosc.toFixed(2) + '</br>Pole powierzchni bocznej:' + pPowierzchniBocznej.toFixed(2) + '</br>Pole calkowite:' + pPowierzchniCalkowitej.toFixed(2);
        document.getElementById('stopka').innerHTML = `</br> Pole podstawy: ${pPodstawy.toFixed(2)} </br>Objetosc: ${objetosc.toFixed(2)} </br>Pole powierzchni bocznej: ${pPowierzchniBocznej.toFixed(2)} </br>Pole calkowite: ${pPowierzchniCalkowitej.toFixed(2)}>`;
    }
}