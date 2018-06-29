function main() {
    const app = document.getElementById('root');
    //console.log(app);

    //const logo = document.createElement('img');
    //logo.src = 'logo.png';

    const container = document.createElement('div');
    container.setAttribute('class', 'container');

    //app.appendChild(logo);
    app.appendChild(container);
    //var click = document.getElementById

    var page = getPage();
    console.log(page);

    //document.getElementById('page').innerText = page;

    url = 'https://api.themoviedb.org/3/discover/movie?page='+page+'&include_video=false&include_adult=false&sort_by=popularity.desc&language=en-US&api_key=b7f9af2647fdef6d0633f07337802317';
    var request = new XMLHttpRequest()
    request.open("GET", url);

    request.onload = function () {

        // Begin accessing JSON data here
        var data = JSON.parse(this.response);
        var movielist = data.results;
        //console.log(movielist);
        //console.log(Number('3') + Number('1'));

        movielist.forEach(movie => {
            // Log each movie's title
            const card = document.createElement('div');
            card.setAttribute('class', 'card');

            const h1 = document.createElement('h1');
            h1.textContent = movie.title;
            //const h2 = document.createElement('h2');
            //h2.textContent = movie.popularity;

            const img = document.createElement("img");
            //movie.overview = movie.overview.substring(0, 300);
            //p.textContent = movie.overview;
            img.src = "https://image.tmdb.org/t/p/w200" + movie.poster_path;


            container.appendChild(card);
            card.appendChild(h1);
            //card.appendChild(h2);
            card.appendChild(img);

        });

    }

    request.send();
}

function next() {
    Ipage = Number(document.getElementById('page').innerText) +1 
    document.getElementById('page').innerText = Ipage.toString();
   
}

function getPage() {
    var pg = document.getElementById('page').innerText;
    console.log(pg);
    return pg;
}