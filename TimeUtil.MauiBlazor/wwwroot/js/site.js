window.parseCSV = async (streamReference) => {
    const arrayBuffer = await streamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const file = new File([blob], 'csvfile');

    const parseRes = await parseCSVAsync(file);
    const events = parseEvents(parseRes.data);

    return JSON.stringify(events);
}

function parseCSVAsync(file) {
    return new Promise((resolve, reject) => {
        const csvParseOptions= {
            complete: (result) => resolve(result),
            header: true,
            skipEmptyLines: true,
            error: (error) => reject(error)
        };
        Papa.parse(file, csvParseOptions);
    });
}

function parseEvents(data) {
    return data.map(x => {
        return {
            eventSubject: x.Subject,
            startDate : x["Start Date"],
            endDate: x["End Date"],
            startTime: x["Start Time"],
            endTime: x["End Time"],
            categories: categoiresConverter(x.Categories),
        };
    })
}

function categoiresConverter(sourceCategorie) {
    if (!sourceCategorie) {
        return ["Uncategorised"];
    }
    return sourceCategorie.split(';');
}