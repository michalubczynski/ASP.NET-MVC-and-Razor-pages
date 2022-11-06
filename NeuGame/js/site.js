
let x_Simp = 100;
let y_Simp = 100;
let x_Potwor = 1500 ;
let y_Potwor = 600;



function Start() {
    document.getElementById('btnStart').setAttribute("disabled", "true");
	setInterval(PotworZblizajacy,100);
}
		document.onkeydown = Przesun;



function Przesun() {
	let szer = document.getElementById('Stage1').offsetWidth;
	let wys = document.getElementById('Stage1').offsetHeight;
    switch (event.keyCode) {
        case 40:
		if(y_Simp < wys - 250){
            y_Simp += 15;
            document.getElementById('postac').src = "../Images/Przod.png";
			}
            break;
        case 38:
		if(y_Simp > -100){
			y_Simp -= 15;
            document.getElementById('postac').src = "../Images/Tyl.png";
		}

            break;
        case 39:
		if(x_Simp < szer-200){
            x_Simp += 15;
            document.getElementById('postac').src = "../Images/Prawo.png";
		}
			break;
        case 37:
		if(x_Simp > - 100){
            x_Simp -= 15;
            document.getElementById('postac').src = "../Images/Lewo.png";
		}
			break;
    }
    document.getElementById('postac').style.left = x_Simp +'px';
    document.getElementById('postac').style.top = y_Simp +'px';

}
	 function PotworZblizajacy(){
	if(x_Simp+100>=x_Potwor)x_Potwor+=5;
	else x_Potwor-=5;
	if(y_Simp+100>=y_Potwor)y_Potwor+=5;
	else y_Potwor-=5;
		document.getElementById('przeciwnikPelzajacy').style.left = x_Potwor +'px';
    document.getElementById('przeciwnikPelzajacy').style.top = y_Potwor +'px';
	
} 


