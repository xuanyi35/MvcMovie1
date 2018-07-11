function main() {
    const app = document.getElementById('root');       
    app.style.display = "none";
    const container = document.createElement('div');                // root append container
    container.setAttribute('class', 'container');
    container.setAttribute('id', 'container');
    app.appendChild(container);
    var page = getPage();
    document.getElementById('page').innerHTML = page;

    url = 'https://api.themoviedb.org/3/discover/movie?page='+page+'&include_video=false&include_adult=false&sort_by=popularity.desc&language=en-US&api_key=b7f9af2647fdef6d0633f07337802317';
    var request = new XMLHttpRequest()
    request.open("GET", url);
    request.onload = function () {

        // Begin accessing JSON data here
        var data = JSON.parse(this.response);
        var movielist = data.results;

    // Log each movie's title & picture
        var mid = 0;
        movielist.forEach(movie => {
            const card = document.createElement('div');
            card.setAttribute('class', 'card');
            card.setAttribute('id', mid);

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

            document.getElementById(mid).onclick = function () {
                console.log(movie.id);
                 window.location.pathname = "../../Home/MovieDetail.cshtml";
            }
            mid = mid + 1;

        });

    }
    request.send();


// add buttons below page
    const bar = document.createElement('div');
    bar.setAttribute('class', 'bar');
    app.appendChild(bar);

    const previous = document.createElement('button');
    previous.setAttribute('id', 'previousBelow');
    previous.setAttribute('class', "btn1");
    previous.style = "background-color:transparent;"
    previous.innerHTML = '<<';
    bar.appendChild(previous);
    document.getElementById('previousBelow').onclick = previousClick;

    const pp = document.createElement('p');
    pp.setAttribute('id', 'pageBelow');
    pp.innerHTML = page;
    bar.appendChild(pp);

    const next = document.createElement('button');
    next.setAttribute('id', 'nextBelow');
    next.setAttribute('class', 'btn1');
    next.style = "background-color:transparent;"
    next.innerHTML = '>>';
    bar.appendChild(next);
    document.getElementById('nextBelow').onclick = nextClick;

    // jump page field
    const tp = document.createElement("INPUT");
    tp.setAttribute("type", "text");
    tp.setAttribute("id", "tpdown");
    tp.style.width = "40px";
    tp.style.marginLeft = "30px";
    bar.appendChild(tp);

    const godown = document.createElement('button');
    godown.setAttribute('id', 'godown');
    godown.setAttribute('class', 'btn1');
    godown.style = "background-color:transparent;"
    godown.innerHTML = 'Go!';
    godown.style.width = "3%";
    bar.appendChild(godown);

    document.getElementById('godown').onclick = jumpPage;

    myVar = setTimeout(showPage, 1000);
    

}

// jump to next page
function nextClick() {
    Ipage = Number(document.getElementById('page').innerText) + 1;
    window.sessionStorage.setItem("page", Ipage.toString());
    location.reload();
   
}

//  jump to previous page
function previousClick() {
    Ipage = Number(document.getElementById('page').innerText) - 1
    if (Ipage > 0) {
        window.sessionStorage.setItem("page", Ipage.toString());
        location.reload();
    }
   
}

// get previous page number
function getPage() {
    var pg = window.sessionStorage.getItem("page");
    if (pg == null) {
       // console.log('1');
        return '1';
    }
    else {
        return pg;
    }

}


// jump to a page by number
function jumpPage() {
    Ipage = document.getElementById('toPage').value;
    document.getElementById('toPage').value = null;
    if (Ipage == '') {
        Ipage = document.getElementById("tpdown").value;
        document.getElementById("tpdown").value = null;
    }
    window.sessionStorage.setItem("page", Ipage);
    location.reload();
}

function showPage() {

    document.getElementById("loader").style.display = "none";
    document.getElementById("root").style.display = "block";
    document.getElementById("myDiv").style.display = "block";
}

