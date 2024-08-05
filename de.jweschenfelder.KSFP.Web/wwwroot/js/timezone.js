function GetDateTime() {
    // Date object will return browser's date and time by default in JavaScript. 
    let normalTime = new Date();
    let shaleTime = new Date();
    shaleTime.setMinutes(shaleTime.getMinutes() + 10);
    let options = {
        year: "numeric", month: "2-digit", day: "2-digit", 
        hour: "2-digit", minute: "2-digit", second: "2-digit"
    };
    document.getElementById("normal-time").innerHTML = normalTime.toLocaleTimeString("en-gb", options);
    document.getElementById("shale-time").innerHTML = shaleTime.toLocaleTimeString("en-gb", options);
}