const Student = function(imie,nazwisko,ocena){
    this.im = imie;
    this.nazw = nazwisko;
    this.oc = ocena;
    Student.studenci;
}

Student.prototype.WyswietlStudenci = () => document.getElementById('tabela').innerHTML = Student.studenci.toString();
Student.prototype.toString = function () { return `Imie: ${this.im} Nazwisko: ${this.nazw} ocena: ${this.oc} <br\>` };

function create() {
    let Student_ = [new Student("Michal", "Judyh", 4), new Student("Michal", "Judyh", 4), new Student("Michal", "Judyh", 4), new Student("Michal", "Judyh", 4), new Student("Michal", "Judyh", 4)];
    Student.studenci = Student_;
}