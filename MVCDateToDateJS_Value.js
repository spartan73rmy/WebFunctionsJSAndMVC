
            function parseDate(date, defaultValue) {
                if (!date) return (getDefaultValue());
                if (typeof (date) === 'date') return (date);
                if (typeof (date) === 'number') return (new Date(date));

                /**
                 * Gets the default value.
                 * returns {Date}
                 */
                function getDefaultValue() {
                    return ((typeof (defaultValue) === 'function') ? defaultValue(name) : defaultValue);
                }

                let results;
                // YYYY-MM-DD
                if ((results = /(\d{4})[-\/\\](\d{1,2})[-\/\\](\d{1,2})/.exec(date))) {
                    return (new Date(results[1], parseInt(results[2], 10) - 1, results[3]) || new Date(date) || getDefaultValue());
                }
                // MM/DD/YYYY
                if ((results = /(\d{1,2})[-\/\\](\d{1,2})[-\/\\](\d{4})/.exec(date))) {
                    date = new Date(results[3], parseInt(results[1], 10) - 1, results[2]) || new Date(date) || getDefaultValue();
                }
                return (new Date(date) || getDefaultValue());
            }

        });


            function formatDateIndeterminado() {
                let dateNow = new Date();
                dateNow.setDate(1);
                dateNow.setMonth(0);
                dateNow.setFullYear(7480);

                let day = ("0" + dateNow.getDate()).slice(-2);
                let month = ("0" + (dateNow.getMonth() + 1)).slice(-2);
                let date = dateNow.getFullYear() + "-" + (month) + "-" + (day);
                return date;
            }

