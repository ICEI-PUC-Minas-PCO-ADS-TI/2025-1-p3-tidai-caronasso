function menuShow() {
    let menuMobile = document.querySelector('.mobile-menu');
    if (menuMobile.classList.contains('open')) {
        menuMobile.classList.remove('open');
        document.querySelector('.icon').src = "../assets/img/menu_white_36dp.svg";
    } else {
        menuMobile.classList.add('open');
        document.querySelector('.icon').src = "../assets/img/close_white_36dp.svg";
    }
}


var btnSignin = document.querySelector("#signin");
var btnSignup = document.querySelector("#signup");

var body = document.querySelector("body");


btnSignin.addEventListener("click", function () {
   body.className = "sign-in-js"; 
});

btnSignup.addEventListener("click", function () {
    body.className = "sign-up-js";
})


//Motorista

document.getElementById("searchBox").addEventListener("change", function () {
    let address = encodeURIComponent(this.value);
    let searchUrl = `https://nominatim.openstreetmap.org/search?q=${address}&format=json`;

    fetch(searchUrl)
        .then((response) => response.json())
        .then((data) => {
            if (data.length > 0) {
                let lat = data[0].lat;
                let lon = data[0].lon;
                let displayName = data[0].display_name;

                // Atualiza o mapa principal
                document.getElementById("mapFrame").src = `https://www.openstreetmap.org/export/embed.html?bbox=${lon - 0.1}%2C${lat - 0.1}%2C${lon + 0.1}%2C${lat + 0.1}&layer=mapnik&marker=${lat}%2C${lon}`;

                // Exibe o endereço ao lado do mapa
                document.getElementById("addressDisplay").innerHTML = `<p><strong>Endereço encontrado:</strong> ${displayName}</p>`;
            } else {
                alert("Local não encontrado.");
            }
        })
        .catch((error) => console.error("Erro ao buscar localização:", error));
});

document.getElementById("addRoute").addEventListener("click", function () {
    let start = document.getElementById("startLocation").value;
    let end = document.getElementById("endLocation").value;
    let time = document.getElementById("rideTime").value;
    let seats = document.getElementById("seatCount").value;

    if (start && end && time && seats) {
        let routeItem = document.createElement("li");
        routeItem.innerHTML = `<p><strong>${start} ➝ ${end}</strong> | Horário: ${time} | Vagas: ${seats}</p>`;
        document.getElementById("routeList").appendChild(routeItem);
    } else {
        alert("Preencha todos os campos para cadastrar a rota.");
    }
});


//Passageiros

// Função para confirmar carona
document.querySelectorAll('.confirm-button').forEach(button => {
    button.addEventListener('click', function() {
        alert("Carona Confirmada!");
    });
})
