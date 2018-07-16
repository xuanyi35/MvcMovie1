var apiurl = 'https://api.themoviedb.org/3/discover/movie?api_key=b7f9af2647fdef6d0633f07337802317&sort_by=popularity.desc&page=1';

function main() {
    const app = document.getElementById('root');       
    app.style.display = "none";
    const container = document.createElement('div');                // root append container
    container.setAttribute('class', 'container1');
    container.setAttribute('id', 'container');
    container.setAttribute("box-sizing"," border-box");
    app.appendChild(container);
    checkURLpage();
    api = getApi();
    if (api.includes("&WithTitle=")){
        const searchstr = document.createElement('h3');
        searchstr.innerHTML = "Serch result for : " + window.sessionStorage.getItem("keystr");
    }

    var page = getPage();
    document.getElementById('page').innerHTML = page;

    var request = new XMLHttpRequest()
    request.open("GET", api);
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
            img.src = "https://image.tmdb.org/t/p/w200" + movie.poster_path;


            container.appendChild(card);                    // container append cards (movies)
            card.appendChild(h1);
            card.appendChild(img);

    
            card.onclick = function () {
                window.sessionStorage.setItem("mid", movie.id);
                window.location.href = "../../Home/MovieDetail";
            }
           
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

    myVar = setTimeout(showPage, 500);
    

}

// jump to next page
function nextClick() {
    Ipage = Number(document.getElementById('page').innerText) + 1;
    window.sessionStorage.setItem("page", Ipage.toString());
    updateURL();
   
}

//  jump to previous page
function previousClick() {
    Ipage = Number(document.getElementById('page').innerText) - 1
    if (Ipage > 0) {
        window.sessionStorage.setItem("page", Ipage.toString());
        updateURL();
    }
   
}

// get previous page number
function getPage() {
    var pg = window.sessionStorage.getItem("page");
    if (pg == '') {
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
    if (Ipage != ''){
        window.sessionStorage.setItem("page", Ipage);
        updateURL();
    }
}

function showPage() {

    document.getElementById("loader").style.display = "none";
    document.getElementById("root").style.display = "block";
    document.getElementById("myDiv").style.display = "block";
}

function updateURL() {
    url = window.location.href;
    addURL = "&page=" + getPage();
    if (url.includes("&page=")) {
        pre = url.split("&page=");
        window.location.href = pre[0] + addURL;
    }
    else {
        window.location.search += addURL;
    }

}


function checkURLpage() {
    current = getPage();
    url = window.location.href;
    if (url.includes("&page=")) {
        newp = url.split("&page=")[1];

        if (!(current === newp)) {
            window.sessionStorage.setItem("page", newp);
        }
    }
    else {
        window.sessionStorage.setItem("page", '1');
    }
    //////// api 
    if (url.includes("&WithTitle=")) {
        window.sessionStorage.setItem("apiurl", 'https://api.themoviedb.org/3/search/movie?api_key=b7f9af2647fdef6d0633f07337802317&query=' + url.split("&WithTitle=")[1]);
    }
    else {
        window.sessionStorage.setItem("apiurl", apiurl);
    }
}


function getApi() {
    var apig = window.sessionStorage.getItem("apiurl");
    if (apig == null) {
        window.sessionStorage.setItem("apiurl", apiurl);
        return apiurl;
    }
    else {
        
        page = getPage();
        pre = apig.split('&page=');
        apig = pre[0] + '&page=' + page;
        console.log(apig);
        window.sessionStorage.setItem("apiurl", apig);
    }
    return apig;
}


function byTitle() {
    key = document.getElementById('key').value;
    console.log(key);
    if (key != '') {
        apiurl = 'https://api.themoviedb.org/3/search/movie?api_key=b7f9af2647fdef6d0633f07337802317&query=' + key + '&page=1'
        window.sessionStorage.setItem("page", '1');
        window.sessionStorage.setItem("apiurl", apiurl);
        window.sessionStorage.setItem("keystr", key);

        url = window.location.href;

        if (url.includes("&page=")) {
            pre = url.split("&page=");
            window.location.href = pre[0] + "&WithTitle=" + key;
        }
        else {
            window.location.search += "&WithTitle=" + key;
        }
    }
}

