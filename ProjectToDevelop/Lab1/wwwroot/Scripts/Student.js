class Student {
    constructor(imie, nazw, ocena) {
        this.imie = imie;
        this.nazw = nazw;
        this.ocena = ocena;
    }
    static studenci;
    toString() {
        return `Imie: ${this.imie} Nazwisko: ${this.nazw} ocena: ${this.ocena} <br\>`;
    }
    static WyswietlStudenci() {
        document.getElementById('tabela').innerHTML = this.studenci.toString();

    }
    static DodajStudent(im, naz, oc) {
        this.studenci.push(new Student(im, naz, oc));
    }
}
function create() {
    Studenci_ = [new Student("Michal", "Iloch", 3), new Student("Michal", "Iloch", 4), new Student("Michal", "Iloch", 5), new Student("Michal", "Iloch", 2), new Student("Michal", "Iloch", 5)];
    Student.studenci = Studenci_;
}