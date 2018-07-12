function mainDetail() {
    mid = window.sessionStorage.getItem("mid").toString();

    url = 'https://api.themoviedb.org/3/movie/' + mid + '?api_key=b7f9af2647fdef6d0633f07337802317&language=en-US';
    var request = new XMLHttpRequest()
    request.open("GET", url);
    request.onload = function () {

        // Begin accessing JSON data here
        var movie = JSON.parse(this.response);
        console.log(movie);
        document.getElementById('t').innerHTML = movie.title;
        document.getElementById('ot').innerHTML = "Original Title: " + movie.original_title;
        document.getElementById('pic').src = "https://image.tmdb.org/t/p/w300" + movie.poster_path;

        const root = document.getElementById('root');
        const genresList = movie.genres;
        genresList.forEach(genre => {

            const p = document.createElement('p');
            p.style.backgroundColor = 'rgb(192, 217, 255)';
            p.style.display = 'inline-block';
            p.style.padding = '5px';
            p.innerHTML = genre.name;
            //const p1 = document.createElement('p');
          // p1.style.display = 'inline-block';
           // p1.innerHTML = '&nbsp;';
            root.appendChild(p);
           // root.appendChild(p1);


        });

        overview = document.getElementById('overview')
        overview.innerHTML = movie.overview;
        overview.style.paddingLeft = "30px";
        if (movie.homepage != null) {
            hp = document.getElementById('hp');
            hp.href = movie.homepage;
            hp.style.paddingLeft = "30px";
        }
    }
    request.send();
}