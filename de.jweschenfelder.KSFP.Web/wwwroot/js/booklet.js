$(function () {

	var bookOptions = {
		centeredWhenClosed: true
		, hardcovers: true
		, toolbar: "home, lastLeft, left, right, lastRight, zoomin, zoomout, slideshow, fullscreen"
		, thumbnailsPosition: 'left'
		, responsiveHandleWidth: 50
		, homeURL: "/KerryShale"
		, flipSound: false

		, container: window
		, containerPadding: "50px"
		, containerBackground: "#ffffff"
		, toolbarContainerPosition: "top" // default "bottom"

		// Uncomment the option toc to create a Table of Contents
		// ,toc: [                    // table of contents in the format
		// 	[ "Introduction", 2 ],  // [ "title", page number ]
		// 	[ "First chapter", 5 ],
		// 	[ "Go to codecanyon.net", "http://codecanyon.net" ] // or [ "title", "url" ]
		// ]
	};

	$('#booklet').wowBook(bookOptions); // create the book

	// How to use wowbook API
	// var book=$.wowBook("#book"); // get book object instance
	// book.gotoPage( 4 ); // call some method

})