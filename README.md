# XE_AspNetCore

## Evento XE Community Meeting - ASP.NET Core vs Node JS del 17-02-2017
Codice della parte riguardante ASP.NET Core.
Slide: https://www.slideshare.net/andreadottor/aspnet-core-72247751

Il codice di Node.js è disponibile nel repository: https://github.com/dmorosinotto/XE_Nodejs

# Demo:
## 1-HELLOWORLD (AspNetCore.DemoWeb1)
Server che risponde su localhost:5001 e ritorna fisso: &lt;h1&gt;Hello World&lt;/h1&gt; con Content-Type=text/plain

## 2-STATICFILE (AspNetCore.DemoWeb2)
Server che risponde su localhost:5002 e server un file page.html e relativo file css, sia quando chiamato direttamente, che quando viene chiamato il website in root "/"


## 3-QUERYSTRING (AspNetCore.DemoWeb3)
Server che risponde su localhost:5003 e che gestisce il GET /add --> metodo che legge dalla query string parametri a, b e ritorna la somma.
Metodo AddJson che ritorna un oggetto JSON { sum: a+b } che valida i parametri in ingresso, e nel caso non siano entrambi numerici ritorna 400 (Bad Request) con testo: "Invalid or missing querystring params a,b number!"

## 4-RESTAPI (AspNetCore.DemoWeb4)
Server che risponde su localhost:5004, con una prima implementazione di API REST che ritorna i dati da un repository MOCK (1000 utenti random). Implementazione dei classici GET /api/users per tornare tutta la lista (array JSON) e GET /api/users/{id} che se trova l'ID nell'array torna il singolo json, altrimenti 404 (NotFound) con messaggio esplicito "Not found user with id=${id}"


## 5-DATABASE (AspNetCore.DemoWeb5)
Server che risponde su localhost:5005 e che implementa una API REST leggendo dati dal DB SQL utilizzando Dapper. Sono State implementate le chiamate GET /customer e GET /customer/{id}.


## 6-MIDDLEWARE (AspNetCore.DemoWeb6 e AspNetCore.DemoWeb6Client)
Aggiunta di CORS e implementazione di un middleware custom che verifica la presenza di un header "X-Auth" e ne controlla il valore (se non è quello voluto, ritorna 401 Unathorized)
