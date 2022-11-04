


function Start() {
    document.getElementById('btnStart').setAttribute("disabled", "disabled");
    //Przesun();

}
let x_Simp = 100
let y_Simp = 100;
document.onkeydown = Przesun;

function Przesun() {
    switch (event.keyCode) {
        case 40:
            y_Simp += 15;
            document.getElementById('postac').src = "../Images/Przod.png"; 
            break;
        case 38:
            y_Simp -= 15;
            document.getElementById('postac').src = "../Images/Tyl.png"; 
            break;
        case 39:
            x_Simp += 15;
            document.getElementById('postac').src = "../Images/Prawo.png";
            break;
        case 37:
            x_Simp -= 15;
            document.getElementById('postac').src = "../Images/Lewo.png";
            break;
    }
    document.getElementById('postac').style.left = x +'px';
    document.getElementById('postac').style.top = y +'px';
}

