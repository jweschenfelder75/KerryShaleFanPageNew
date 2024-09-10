import * as THREE from 'three';

import { OrbitControls } from 'three/addons/controls/OrbitControls.js';
import { TeapotGeometry } from 'three/addons/geometries/TeapotGeometry.js';

let camera, scene, renderer;
let cameraControls;
let effectController = {
	newTess: 15,
	bottom: true,
	lid: true,
	body: true,
	fitLid: false,
	nonblinn: false,
	newShading: 'test'
};
const teapotSize = 300;
let ambientLight, light;

let tess = - 1;	// force initialization
let bBottom;
let bLid;
let bBody;
let bFitLid;
let bNonBlinn;
let shading;

let teapot, textureCube;
const materials = {};

init();
render();

function init() {
	const canvas = document.getElementById('canvasId');

	const canvasWidth = canvas.offsetWidth;
	const canvasHeight = canvas.offsetHeight;

	// CAMERA
	camera = new THREE.PerspectiveCamera(20, canvasWidth / canvasHeight, 1, 80000);
	camera.position.set(- 2000, 550, 1300);

	// LIGHTS
	ambientLight = new THREE.AmbientLight(0x7c7c7c, 3.0);

	light = new THREE.DirectionalLight(0xFFFFFF, 3.0);
	light.position.set(0.32, 0.39, 0.7);

	// RENDERER
	renderer = new THREE.WebGLRenderer({ antialias: true });
	renderer.setPixelRatio(window.devicePixelRatio);
	renderer.setSize(canvasWidth, canvasHeight);
	canvas.appendChild(renderer.domElement);

	// EVENTS
	window.addEventListener('resize', onWindowResize);

	// CONTROLS
	cameraControls = new OrbitControls(camera, renderer.domElement);
	cameraControls.addEventListener('change', render);

	// TEXTURE MAP
	const textureMap = new THREE.TextureLoader().load('./js/webgl/three/examples/textures/uv_grid_opengl.jpg');
	textureMap.wrapS = textureMap.wrapT = THREE.RepeatWrapping;
	textureMap.anisotropy = 16;
	textureMap.colorSpace = THREE.SRGBColorSpace;

	// REFLECTION MAP
	const path = './js/webgl/three/examples/textures/cube/pisa/';
	const urls = ['px.png', 'nx.png', 'py.png', 'ny.png', 'pz.png', 'nz.png'];

	textureCube = new THREE.CubeTextureLoader().setPath(path).load(urls);

	materials['wireframe'] = new THREE.MeshBasicMaterial({ wireframe: true });
	materials['flat'] = new THREE.MeshPhongMaterial({ color: 0x00FF00, specular: 0x000000, flatShading: true, side: THREE.DoubleSide });
	materials['smooth'] = new THREE.MeshLambertMaterial({ color: 0x00FF00, side: THREE.DoubleSide });
	materials['glossy'] = new THREE.MeshPhongMaterial({ color: 0x00FF00, side: THREE.DoubleSide });
	materials['textured'] = new THREE.MeshPhongMaterial({ color: 0x00FF00, map: textureMap, side: THREE.DoubleSide });
	materials['reflective'] = new THREE.MeshPhongMaterial({ color: 0x00FF00, envMap: textureCube, side: THREE.DoubleSide });
	materials['test'] = new THREE.MeshNormalMaterial({ color: 0x7c00c7, wireframe: false });

	// scene itself
	scene = new THREE.Scene();
	scene.background = new THREE.Color(0xAAAAAA);

	scene.add(ambientLight);
	scene.add(light);
}

// EVENT HANDLERS

function onWindowResize() {

	const canvasWidth = canvas.offsetWidth;
	const canvasHeight = canvas.offsetHeight;

	renderer.setSize(canvasWidth, canvasHeight);

	camera.aspect = canvasWidth / canvasHeight;
	camera.updateProjectionMatrix();

	render();

}

function render() {

	if (effectController.newTess !== tess ||
		effectController.bottom !== bBottom ||
		effectController.lid !== bLid ||
		effectController.body !== bBody ||
		effectController.fitLid !== bFitLid ||
		effectController.nonblinn !== bNonBlinn ||
		effectController.newShading !== shading) {

		tess = effectController.newTess;
		bBottom = effectController.bottom;
		bLid = effectController.lid;
		bBody = effectController.body;
		bFitLid = effectController.fitLid;
		bNonBlinn = effectController.nonblinn;
		shading = effectController.newShading;

		createNewTeapot();
	}

	// skybox is rendered separately, so that it is always behind the teapot.
	if (shading === 'reflective') {

		scene.background = textureCube;

	} else {

		scene.background = null;

	}

	renderer.render(scene, camera);

}

// Whenever the teapot changes, the scene is rebuilt from scratch (not much to it).
function createNewTeapot() {

	if (teapot !== undefined) {

		teapot.geometry.dispose();
		scene.remove(teapot);

	}

	const geometry = new TeapotGeometry(teapotSize,
		tess,
		effectController.bottom,
		effectController.lid,
		effectController.body,
		effectController.fitLid,
		!effectController.nonblinn);

	teapot = new THREE.Mesh(geometry, materials[shading]);

	scene.add(teapot);
}
