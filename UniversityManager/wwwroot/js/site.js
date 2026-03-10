document.addEventListener("DOMContentLoaded", () => getData());

let mapStudentTemplate = (student) => {
    
    return `<tr>
            <td>${student.id}</td>
            <td>${student.name}</td>
            <td>${student.surname}</td>
            <td>${student.birthDate}</td>
            <td>QUI TASTO PER DETTAGLI</td>
            </tr>`
}
let getData = () => {
    fetch("/api/student")
        .then(response => response.json())
        .then(data => insertDataInTable(data));
    console.log("Ciao");
}
let insertDataInTable = (data) => {
    var tbody = data.map(mapStudentTemplate).join('');
    document.getElementById("table_body").innerHTML = tbody;
}