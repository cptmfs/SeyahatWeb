/**
 * cite.js
 *
 * Copyright 2009, Moxiecode Systems AB
 * Released under LGPL License.
 *
 * License: //tinymce.moxiecode.com/license
 * Contributing: //tinymce.moxiecode.com/contributing
 */

function init() {
	SXE.initElementDialog('cite');
	if (SXE.currentAction == "update") {
		SXE.showRemoveButton();
	}
}

function insertCite() {
	SXE.insertElement('cite');
	tinyMCEPopup.close();
}

function removeCite() {
	SXE.removeElement('cite');
	tinyMCEPopup.close();
}

tinyMCEPopup.onInit.add(init);
