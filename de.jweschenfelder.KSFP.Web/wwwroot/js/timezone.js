function GetDateTime() {
    // Date object will return browser's date and time by default in JavaScript. 
    let normalTime = new Date();
    let options = {
        year: "numeric", month: "2-digit", day: "2-digit", 
        hour: "2-digit", minute: "2-digit", second: "2-digit", 
        hourCycle: "h23"
    };
    return normalTime.toLocaleTimeString("en-GB", options);
}
