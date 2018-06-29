function main() {
    const body = document.getElementById('moviesL');

    const app = document.createElement('div');
    app.setAttribute('id', 'root');
    body.appendChild(app);                          // body append root

    const container = document.createElement('div');                // root append container
    container.setAttribute('class', 'container');
    app.appendChild(container);

    var page = getPage();
    url = 'https://api.themoviedb.org/3/discover/movie?page='+page+'&include_video=false&include_adult=false&sort_by=popularity.desc&language=en-US&api_key=b7f9af2647fdef6d0633f07337802317';
    var request = new XMLHttpRequest()
    request.open("GET", url);
    request.onload = function () {

        // Begin accessing JSON data here
        var data = JSON.parse(this.response);
        var movielist = data.results;

    // Log each movie's title & picture
        movielist.forEach(movie => {
            const card = document.createElement('div');
            card.setAttribute('class', 'card');

            const h1 = document.createElement('h1');
            h1.textContent = movie.title;
           
            const img = document.createElement("img");
            //movie.overview = movie.overview.substring(0, 300);
            //p.textContent = movie.overview;
            img.src = "https://image.tmdb.org/t/p/w200" + movie.poster_path;


            container.appendChild(card);                    // container append cards (movies)
            card.appendChild(h1);
            //card.appendChild(h2);
            card.appendChild(img);

        });

    }
    request.send();


// add buttons below page
    const bar = document.createElement('div');
    bar.setAttribute('class', 'bar');
    app.appendChild(bar);

    const previous = document.createElement('button');
    previous.setAttribute('id', 'previousBelow');
    previous.innerHTML = '<';
    bar.appendChild(previous);
    document.getElementById('previousBelow').onclick = previousClick;

    const pp = document.createElement('p');
    pp.setAttribute('id', 'pageBelow');
    pp.style.display ='inline-block';
    pp.innerHTML = document.getElementById('page').innerHTML;
    bar.appendChild(pp);

    const next = document.createElement('button');
    next.setAttribute('id', 'nextBelow');
    next.innerHTML = '>';
    bar.appendChild(next);
    document.getElementById('nextBelow').onclick = nextClick;

}

// jump to next page
function nextClick() {
    Ipage = Number(document.getElementById('page').innerText) +1 
    document.getElementById('page').innerText = Ipage.toString();
    const body = document.getElementById('moviesL');            // remove previous content "root"
    const app = document.getElementById('root');
    body.removeChild(app);
    main(Ipage.toString());
   
}

//  jump to previous page
function previousClick() {
    Ipage = Number(document.getElementById('page').innerText) -1
    if (Ipage > 0 ){
        document.getElementById('page').innerText = Ipage.toString();
        const body = document.getElementById('moviesL');            // remove previous content "root"
        const app = document.getElementById('root');
        body.removeChild(app);
        main(Ipage.toString());
    }
   
}

// get previous page number
function getPage() {
    var pg = document.getElementById('page').innerText;
    console.log(pg);
    return pg;
}