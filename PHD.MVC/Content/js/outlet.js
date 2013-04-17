	$(function() {
		var availableTags = [
			"ABDUL MUIS(GEDUNG DINAS TEKNIS), Jakarta Pusat - PHD Hasyim Asharit",
			"AB, Jakarta Barat - PHD Pos Pengumben",
			"ABADI, Tangerang - PHD Bintaro",
			"ABADI, Bekasi - PHD Jati Makmur",
			"ABDUL MUIS(GEDUNG DINAS TEKNIS), Jakarta Pusat - PHD Hasyim Asharit",
			"AB, Jakarta Barat - PHD Pos Pengumben",
			"ABADI, Tangerang - PHD Bintaro",
			"ABADI, Bekasi - PHD Jati Makmur",
			"ABDUL MUIS(GEDUNG DINAS TEKNIS), Jakarta Pusat - PHD Hasyim Asharit",
			"AB, Jakarta Barat - PHD Pos Pengumben",
			"ABADI, Tangerang - PHD Bintaro",
			"ABADI, Bekasi - PHD Jati Makmur",			
			"ABADI, Jakarta Timur - PHD Cibubur Indah"  
		];
		$( "#txtSearch" ).autocomplete({
			source: availableTags, 
			collision: "flip"
		});
	});