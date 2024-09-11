import * as THREE from 'three';

import { OrbitControls } from 'three/addons/controls/OrbitControls.js';
import { FBXLoader } from 'three/addons/loaders/FBXLoader.js';

const manager = new THREE.LoadingManager();

let camera, scene, renderer, object, loader;
let mixer;

const clock = new THREE.Clock();

const canvas = document.getElementById('canvasId');

const canvasWidth = canvas.offsetWidth;
const canvasHeight = canvas.offsetHeight;

init();

function init() {

	camera = new THREE.PerspectiveCamera(35, canvasWidth / canvasHeight, 1, 2000);
	camera.position.set(50, 125, 250);

	scene = new THREE.Scene();
	scene.background = new THREE.Color(0xa0a0a0);
	scene.fog = new THREE.Fog(0xa0a0a0, 200, 1000);

	const hemiLight = new THREE.HemisphereLight(0xffffff, 0x444444, 4);
	hemiLight.position.set(0, 200, 0);
	scene.add(hemiLight);

	const dirLight = new THREE.DirectionalLight(0xffffff, 2);
	dirLight.position.set(0, 100, 200);
	dirLight.castShadow = true;
	dirLight.shadow.camera.top = 180;
	dirLight.shadow.camera.bottom = - 100;
	dirLight.shadow.camera.left = - 120;
	dirLight.shadow.camera.right = 120;
	scene.add(dirLight);

	// scene.add( new THREE.CameraHelper( dirLight.shadow.camera ) );

	// ground
	const mesh = new THREE.Mesh(new THREE.PlaneGeometry(2000, 2000), new THREE.MeshPhongMaterial({ color: 0x999999, depthWrite: false }));
	mesh.rotation.x = - Math.PI / 2;
	mesh.receiveShadow = true;
	scene.add(mesh);

	const grid = new THREE.GridHelper(2000, 20, 0x000000, 0x000000);
	grid.material.opacity = 0.2;
	grid.material.transparent = true;
	scene.add(grid);

	loader = new FBXLoader(manager);
	loadAsset();

	renderer = new THREE.WebGLRenderer({ antialias: true });
	renderer.setPixelRatio(window.devicePixelRatio);
	renderer.setSize(canvasWidth, canvasHeight);
	renderer.setAnimationLoop(animate);
	renderer.shadowMap.enabled = true;
	canvas.appendChild(renderer.domElement);

	const controls = new OrbitControls(camera, renderer.domElement);
	controls.target.set(0, 100, 0);
	controls.update();

	window.addEventListener('resize', onWindowResize);

}

function loadAsset() {

	loader.load('./js/webgl/three/examples/models/fbx/KS2.fbx', function (group) {

		if (object) {

			object.traverse(function (child) {

				if (child.material) {

					const materials = Array.isArray(child.material) ? child.material : [child.material];
					materials.forEach(material => {

						if (material.map) material.map.dispose();
						material.dispose();

					});

				}

				if (child.geometry) child.geometry.dispose();

			});

			scene.remove(object);

		}

		object = group;

		if (object.animations && object.animations.length) {

			mixer = new THREE.AnimationMixer(object);

			const action = mixer.clipAction(object.animations[0]);
			action.play();

		} else {

			mixer = null;

		}

		object.rotateX(Math.PI / 180 * 270)

		scene.add(object);

	});

}

function onWindowResize() {

	camera.aspect = canvasWidth / canvasHeight;
	camera.updateProjectionMatrix();

	renderer.setSize(canvasWidth, canvasHeight);

}

function animate() {

	const delta = clock.getDelta();

	if (mixer) mixer.update(delta);

	renderer.render(scene, camera);

}
