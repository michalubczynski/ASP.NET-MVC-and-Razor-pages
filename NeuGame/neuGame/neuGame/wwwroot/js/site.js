
let x_Simp = 100;
let y_Simp = 100;
let x_Potwor;
let y_Potwor;
let x_PotworJ = 700;
let y_PotworJ = 10;
let czyWdol = true;
let myInterval;
let punktacja = 0;


function Start() {
	document.getElementById('btnStart').setAttribute("disabled", "true");
	do {
		x_Potwor = Math.floor(Math.random() * 1500);
		y_Potwor = Math.floor(Math.random() * 900);
	} while (Math.sqrt(((x_Potwor - x_Simp) * (x_Potwor - x_Simp)) + ((y_Potwor - y_Simp) * (y_Potwor - y_Simp))) < 200);

	var element = document.createElement("img");
	element.src = "../Images/orb.gif";
	element.id = "przeciwnikPelzajacy";
	element.style.visibility = 'hidden';
	document.getElementById('Stage1').appendChild(element);
	var element2 = document.createElement("img");
	element2.src = "../Images/orb.gif";
	element2.id = "przeciwnikJezdzacy";
	document.getElementById('Stage1').appendChild(element2);
	document.onkeydown = Przesun;
	myInterval =  setInterval(Przeciwnicy, 100);


}



function Przesun() {
	let szer = document.getElementById('Stage1').offsetWidth;
	let wys = document.getElementById('Stage1').offsetHeight;
    switch (event.keyCode) {
        case 40:
		if(y_Simp < wys - 80){
            y_Simp += 15;
            document.getElementById('postac').src = "../Images/Przod.png";
			}
            break;
        case 38:
		if(y_Simp > -30){
			y_Simp -= 15;
            document.getElementById('postac').src = "../Images/Tyl.png";
		}

            break;
        case 39:
		if(x_Simp < szer - 50){
            x_Simp += 15;
            document.getElementById('postac').src = "../Images/Prawo.png";
		}
			break;
        case 37:
		if(x_Simp > -20){
            x_Simp -= 15;
            document.getElementById('postac').src = "../Images/Lewo.png";
		}
			break;
	}

    document.getElementById('postac').style.left = x_Simp +'px';
	document.getElementById('postac').style.top = y_Simp + 'px';
	if (x_Simp >= 1450) {
		window.alert("UZYTKOWNIKU wygrales z puntkacja: "+punktacja);
		clearInterval(myInterval);
		location.reload();
	}

}
function Przeciwnicy() {
	punktacja+=10;
	PotworJezdzacy();
	PotworZblizajacy();
	document.getElementById('punktacja').innerHTML = "Exp: "+ punktacja;

}
function PotworZblizajacy() {
	document.getElementById('przeciwnikPelzajacy').style.visibility = 'visible';
	if (x_Simp + 50 >= x_Potwor) x_Potwor += 5;
	else { x_Potwor -= 5; }
	if (y_Simp + 50 >= y_Potwor) y_Potwor += 5;
	else {y_Potwor -= 5;}
	document.getElementById('przeciwnikPelzajacy').style.left = x_Potwor +'px';
	document.getElementById('przeciwnikPelzajacy').style.top = y_Potwor + 'px';
	if (Math.sqrt(((x_Potwor - x_Simp) * (x_Potwor - x_Simp)) + ((y_Potwor - y_Simp) * (y_Potwor - y_Simp))) < 80) {
		window.alert("UZYTKOWNIKU PRZEGRALES");
		clearInterval(myInterval);
		location.reload();
    }
	
} 
function PotworJezdzacy() {
	if (czyWdol == true) {
		y_PotworJ += 30;
		if (y_PotworJ >= 900) {
        }
			czyWdol = false;
	}
	if (czyWdol == false ) {
		y_PotworJ -= 30;
		if (y_PotworJ <= 10) {
			czyWdol = true;
		}
	}
	document.getElementById('przeciwnikJezdzacy').style.left = x_PotworJ + 'px';
	document.getElementById('przeciwnikJezdzacy').style.top = y_PotworJ + 'px';
	if (Math.sqrt(((x_PotworJ - x_Simp) * (x_PotworJ - x_Simp)) + ((y_PotworJ - y_Simp) * (y_PotworJ - y_Simp))) < 80) {
		window.alert("UZYTKOWNIKU PRZEGRALES");
		clearInterval(myInterval);
		location.reload();
	}

} 


