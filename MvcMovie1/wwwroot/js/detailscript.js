function mainDetail() {
    updateMid();
    mid = window.sessionStorage.getItem("mid").toString();

    document.getElementById('passvalue').value = mid;
    
    url = 'https://api.themoviedb.org/3/movie/' + mid + '?api_key=b7f9af2647fdef6d0633f07337802317&language=en-US';
    var request = new XMLHttpRequest()
    request.open("GET", url);
    request.onload = function () {

        // Begin accessing JSON data here
        var movie = JSON.parse(this.response);
        try {
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
                root.appendChild(p);



            });

            overview = document.getElementById('overview')
            overview.innerHTML = movie.overview;
            overview.style.paddingLeft = "10px";

            collection = document.getElementById('collection')
            collection.innerHTML = movie.belongs_to_collection.name;
            collection.style.paddingLeft = "10px";

            rdate = document.getElementById('rdate')
            rdate.innerHTML = movie.release_date;
            rdate.style.paddingLeft = "30px";

            if (movie.homepage != null) {
                hp.href = movie.homepage;
                hp = document.getElementById('hp');
                hp.innerHTML = "  Go to home page  "
            }
            else {
                hp = document.getElementById('hp').style.display = "none";
            }
        }
        catch (err) {
            //
        }
        getVideo(mid);
        getSimilar(mid);

    }
    request.send();
    updateURL();
}




function updateURL() {
    url = window.location.href;
    addURL = "?mid=" + window.sessionStorage.getItem("mid").toString();
    if (url.includes("?mid=")) {
        pre = url.split("?mid=");
        if (! (pre[1] === window.sessionStorage.getItem("mid").toString()) ){
            window.location.href = pre[0] + addURL;
        }
    }
    else {
        window.location.search += addURL;
    }

}

function updateMid() {
    url = window.location.href;
    if (url.includes("?mid=")) {
        newMID = url.split("?mid=")[1];
        current  = window.sessionStorage.getItem("mid").toString()
        if (!(current === newMID)) {
            window.sessionStorage.setItem("mid", newMID);
        }
    }  
}





function getVideo(mid) {
    var link = 'https://www.youtube.com/embed/';
    api = 'https://api.themoviedb.org/3/movie/' + mid + '/videos?api_key=b7f9af2647fdef6d0633f07337802317';
    var request = new XMLHttpRequest()
    request.open("GET", api);
    request.onload = function () {

        // Begin accessing JSON data here
        var videos = JSON.parse(this.response).results;
        var i;
        for (i = 0; i < videos.length; i++){
            if (videos[i].type == "Trailer") {
                link += videos[i].key;
                break;
            }
        }

        console.log(link)
        const video = document.createElement('IFRAME');
        video.setAttribute('allowFullScreen', '')
        video.style.border = "0";
        video.src = link;
        document.getElementById('id').appendChild(video);
    }
    request.send();
}


function getSimilar(mid) {
    const h3 = document.createElement('h3');
    h3.innerHTML = "Similar Movies";
    h3.style.marginLeft = "5%";
    const container = document.createElement('div');
    container.setAttribute("class", "container2");
    document.getElementById('id').appendChild(h3);
    document.getElementById('id').appendChild(container);
    //const container = document.getElementById("movieIMG");
    api = 'https://api.themoviedb.org/3/movie/' + mid + '/similar?api_key=b7f9af2647fdef6d0633f07337802317&page=1';

    var request = new XMLHttpRequest()
    request.open("GET", api);
    request.onload = function () {

        // Begin accessing JSON data here
        var moviess = JSON.parse(this.response).results;
        moviess.forEach(movie => {
            const card = document.createElement('div');
            card.setAttribute('class', 'card2');

            const p = document.createElement('p');
            p.textContent = movie.title;

            const img = document.createElement("img");
            img.src = "https://image.tmdb.org/t/p/w200" + movie.poster_path;

            container.appendChild(card);                    // container append cards (movies)
            card.appendChild(img);
            card.appendChild(p);

            card.onclick = function () {
                window.sessionStorage.setItem("mid", movie.id);
                window.location.href = "../../Home/MovieDetail?mid=" + movie.id;
            }

        });

    }
    request.send();

}


