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


//mapa

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

// Mapa e busca de endereço
document.getElementById("searchBox").addEventListener("change", function () {
    let address = encodeURIComponent(this.value);
    let searchUrl = `https://nominatim.openstreetmap.org/search?q=${address}&format=json`;

    fetch(searchUrl)
        .then((response) => response.json())
        .then((data) => {
            if (data.length > 0) {
                let lat = data[0].lat;
                let lon = data[0].lon;

                // Atualiza o mapa principal
                document.getElementById("mapFrame").src = `https://www.openstreetmap.org/export/embed.html?bbox=${lon - 0.1}%2C${lat - 0.1}%2C${lon + 0.1}%2C${lat + 0.1}&layer=mapnik&marker=${lat}%2C${lon}`;
                
                // Atualiza a lista de locais com o mini-mapa
                let locationItem = document.createElement("li");

                let miniMap = document.createElement("iframe");
                miniMap.className = "mini-map";
                miniMap.src = `https://www.openstreetmap.org/export/embed.html?bbox=${lon - 0.01}%2C${lat - 0.01}%2C${lon + 0.01}%2C${lat + 0.01}&layer=mapnik&marker=${lat}%2C${lon}`;

                let locationText = document.createElement("p");
                locationText.innerHTML = `${data[0].display_name}`;

                locationItem.appendChild(miniMap);
                locationItem.appendChild(locationText);

                // Verifica se o local já foi adicionado
                const locationList = document.getElementById("locationList");
                const existingLocations = locationList.querySelectorAll("li");
                let alreadyExists = false;
                existingLocations.forEach((existingItem) => {
                    if (existingItem.textContent.trim() === data[0].display_name) {
                        alreadyExists = true;
                    }
                });

                if (!alreadyExists) {
                    locationList.appendChild(locationItem);
                } else {
                    alert("Este local já foi adicionado.");
                }

                // Limpa o campo de pesquisa
                document.getElementById("searchBox").value = "";

            } else {
                alert("Local não encontrado.");
            }
        })
        .catch((error) => console.error("Erro ao buscar localização:", error));
});
