SELECT *
FROM Users
WHERE
    remove = false
    AND (
        (@Search IS NULL OR FirstName LIKE '%' || @Search || '%')
        OR (@Search IS NULL OR Surname LIKE '%' || @Search || '%')
    )
OFFSET (@PageNumber - 1) * @PageSize
FETCH NEXT @PageSize ROWS ONLY;
